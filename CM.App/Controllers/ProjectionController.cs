using CM.Common.BindingModels;
using CM.Common.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly IProjectionService service;

        public ProjectionController(IProjectionService projectionService)
        {
            this.service = projectionService;
        }

        public IHttpActionResult Get(int id)
        {
            var projection = this.service.GetById(id);

            if (projection == null)
            {
                return NotFound();
            }

            return Ok(projection);
        }

        [HttpGet]
        [ActionName("GetUnstarted")]
        public IHttpActionResult GetUnstarted()
        {
            var projections = this.service.GetAllUnstarted();

            return Ok(projections);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IHttpActionResult> Create(CreateProjectionBindingModel model)
        {
            var projection = this.service.GetByModel(model);

            if (projection != null)
            {
                return BadRequest("Projection already exists");
            }

            var result = await this.service.Insert(model);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Message);
            }

            return Ok(projection);
        }

        [ActionName("GetAvailableSeats")]
        public IHttpActionResult GetAvailableSeats(int id)
        {
            var projection = this.service.GetById(id);

            if (projection == null)
            {
                return BadRequest("Projection not found");
            }

            bool isStarted = DateTime.Compare(projection.StartDate, DateTime.UtcNow) < 0;

            if (isStarted)
            {
                return BadRequest("Projection started");
            }

            int count = projection.AvailableSeatsCount;

            return Ok(count);
        }
    }
}
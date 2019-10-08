
using CM.Services;
using CM.Services.Dtos;
using CM.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly ProjectionService service;

        public ProjectionController(ProjectionService projectionService)
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
        public IHttpActionResult Create(ProjectionCreationModel model)
        {
            var projection = this.service.GetByModel(model);

            if (projection != null)
            {
                return BadRequest("Projection already exists");
            }

            var result = this.service.Insert(model);

            if (!result.IsCreated)
            {
                return BadRequest(result.Message);
            }

            return Ok(projection);
        }

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

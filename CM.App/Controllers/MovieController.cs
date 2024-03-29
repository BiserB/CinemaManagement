﻿
using CM.Common.BindingModels;
using CM.Common.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieService service;

        public MovieController(IMovieService movieService)
        {
            this.service = movieService;
        }

        public IHttpActionResult Get(int id)
        {
            var movie = this.service.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(CreateMovieBindingModel model)
        {
            var movie = this.service.GetByNameAndDuration(model.Name, model.DurationMinutes);

            if (movie != null)
            {
                return BadRequest("Movie already exists");
            }

            bool isCreated = await this.service.Insert(model);

            if (!isCreated)
            {
                return BadRequest("Error while creating a movie");
            }

            return Ok(movie);
        }
    }
}
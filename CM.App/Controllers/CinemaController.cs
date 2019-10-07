using CM.Services;
using CM.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class CinemaController : ApiController
    {
        private readonly CinemaService service;

        public CinemaController(CinemaService cinemaService)
        {
            this.service = cinemaService;
        }

        [HttpGet]
        [ActionName("GetCinema")]
        public IHttpActionResult GetCinema(int id)
        {
            var cinema = this.service.GetById(id);

            return Ok(cinema);
        }

        [HttpGet]
        [ActionName("GetCinemaList")]
        public IHttpActionResult GetCinemaList()
        {
            var cinemaList = this.service.GetCinemaList();

            return Ok(cinemaList);
        }

        [HttpPost]
        [ActionName("CreateCinema")]
        public IHttpActionResult CreateCinema(CinemaCreationModel model)
        {
            var isCreated = this.service.CreateCinema(model);

            if (isCreated)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}

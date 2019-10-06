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
        public IHttpActionResult GetCinema()
        {
            this.service.GetByNameAndAddress("", "");

            return Ok();
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

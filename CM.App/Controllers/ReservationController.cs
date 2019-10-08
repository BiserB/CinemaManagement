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
    public class ReservationController : ApiController
    {
        private readonly ReservationService service;

        public ReservationController(ReservationService reservationService)
        {
            this.service = reservationService;
        }

        [HttpPost]
        public IHttpActionResult Make(ReservationModel model)
        {
            var result = this.service.MakeReservation(model);

            if(!result.IsCreated)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.ReservationTicket);
        }
    }
}

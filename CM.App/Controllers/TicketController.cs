﻿using CM.Services;
using CM.Services.Contracts;
using CM.Services.InputModels;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class TicketController : ApiController
    {
        private TicketService service;

        public TicketController(TicketService ticketService)
        {
            this.service = ticketService;
        }

        [HttpPost]
        [ActionName("Buy")]
        public IHttpActionResult Buy(TicketModel model)
        {
            ActionSummary result;

            if (model.ReservationId == 0)
            {
                result = this.service.Buy(model);
            }
            else
            {
                result = this.service.BuyReserved(model);
            }

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
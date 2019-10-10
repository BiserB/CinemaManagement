using CM.Services;
using CM.Services.InputModels;
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
        [ActionName("Make")]
        public IHttpActionResult Make(ReservationModel model)
        {
            var result = this.service.MakeReservation(model);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.ReservationTicket);
        }

        [HttpPost]
        [ActionName("Cancel")]
        public IHttpActionResult Cancel(int id)
        {
            var result = this.service.Cancel(id);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
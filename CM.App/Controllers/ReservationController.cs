using CM.Common.BindingModels;
using CM.Common.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationService service;

        public ReservationController(IReservationService reservationService)
        {
            this.service = reservationService;
        }

        [HttpPost]
        [ActionName("Make")]
        public async Task<IHttpActionResult> Make(CreateReservationBindingModel model)
        {
            var result = await this.service.MakeReservation(model);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.ReservationTicket);
        }

        [HttpPost]
        [ActionName("Cancel")]
        public async Task<IHttpActionResult> Cancel(int id)
        {
            var result = await this.service.Cancel(id);

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
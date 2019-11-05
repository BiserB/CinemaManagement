using CM.Common.BindingModels;
using CM.Common.Interfaces;
using CM.Common.ResultModels;
using System.Threading.Tasks;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class TicketController : ApiController
    {
        private ITicketService service;

        public TicketController(ITicketService ticketService)
        {
            this.service = ticketService;
        }

        [HttpPost]
        [ActionName("Buy")]
        public async Task<IHttpActionResult> Buy(CreateTicketBindingModel model)
        {
            ActionSummary result;

            if (model.ReservationId == 0)
            {
                result = await this.service.Buy(model);
            }
            else
            {
                result = await this.service.BuyReserved(model);
            }

            if (!result.IsSuccessful)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
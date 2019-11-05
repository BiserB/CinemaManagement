using CM.Common.BindingModels;
using CM.Common.ResultModels;
using System.Threading.Tasks;

namespace CM.Common.Interfaces
{
    public interface ITicketService
    {
        Task<ActionSummary> Buy(CreateTicketBindingModel model);

        Task<ActionSummary> BuyReserved(CreateTicketBindingModel model);
    }
}

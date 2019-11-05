using CM.Common.BindingModels;
using CM.Common.DTOs;
using CM.Common.ResultModels;
using System.Threading.Tasks;

namespace CM.Common.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationSummary> MakeReservation(CreateReservationBindingModel model);

        Task<ActionSummary> Cancel(int id);

        ReservationDto GetById(long id);
    }
}

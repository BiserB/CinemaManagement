using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Data;
using CM.Entities;
using CM.Services.Contracts;
using CM.Services.InputModels;

namespace CM.Services
{
    public class ReservationService : BaseService
    {
        public ReservationService(CinemaDbContext dbContext) 
            : base(dbContext)
        {
        }

        public ActionSummary MakeReservation(ReservationModel model)
        {
            var projection = this.DbContext.Projections.FirstOrDefault(p => p.Id == model.ProjectionId);

            if (projection == null)
            {
                return new ActionSummary(false, $"Projection with id {model.ProjectionId} does not exist");
            }

            bool isStarted = projection.StartDate < DateTime.UtcNow;
            bool isToLate = projection.StartDate < DateTime.UtcNow.AddMinutes(10);

            if (isStarted || isToLate)
            {
                return new ActionSummary(false, $"Reservation for this projection are closed");
            }

            var room = this.DbContext.Rooms.FirstOrDefault(r => r.Id == projection.RoomId);
            
            bool isValidRow = model.Row > 0 && model.Row <= room.Rows;
            bool isValidRColumn = model.Column > 0 && model.Column <= room.SeatsPerRow;

            if (!isValidRow || !isValidRColumn)
            {
                return new ActionSummary(false, $"Invalid seat place");
            }

            bool isReserved = this.DbContext.Reservations.Where(r => r.ProjectionId == model.ProjectionId)
                                                          .FirstOrDefault(r => r.Row == model.Row && r.Column == model.Column)
                                                          .Equals(null);

            if (isReserved)
            {
                return new ActionSummary(false, $"Place is reserved");
            }

            Reservation newReservation = new Reservation();
            newReservation.ProjectionId = projection.Id;
            newReservation.Row = model.Row;
            newReservation.Column = model.Column;

            this.DbContext.Reservations.Add(newReservation);

            int rowsAffected = this.DbContext.SaveChanges();

            return new ActionSummary(rowsAffected == 1);
        }
    }
}
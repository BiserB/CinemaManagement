using CM.Data;
using CM.Entities;
using CM.Models.BindingModels;
using CM.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Services
{
    public class TicketService : BaseService
    {
        private const int MINUTES_BEFORE_PROJECTION = 10;

        public TicketService(CinemaDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<ActionSummary> Buy(CreateTicketBindingModel model)
        {
            var projection = this.DbContext.Projections.FirstOrDefault(p => p.Id == model.ProjectionId);

            if (projection == null)
            {
                return new ActionSummary(false, $"No projection with Id {model.ProjectionId}");
            }

            if (projection.StartDate < DateTime.UtcNow)
            {
                return new ActionSummary(false, $"You can't buy ticket for projection with start date {projection.StartDate}");
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

            bool isSold = this.DbContext.Tickets.Where(t => t.ProjectionId == model.ProjectionId)
                                                .FirstOrDefault(r => r.Row == model.Row && r.Column == model.Column)
                                                .Equals(null);

            if (isReserved || isSold)
            {
                return new ActionSummary(false, $"The place is occupied");
            }

            Ticket newTicket = new Ticket();

            newTicket.ProjectionId = model.ProjectionId;
            newTicket.Row = model.Row;
            newTicket.Column = model.Column;

            this.DbContext.Tickets.Add(newTicket);

            int rowsAffected = await this.DbContext.SaveChangesAsync();

            return new ActionSummary(rowsAffected == 1);
        }

        public async Task<ActionSummary> BuyReserved(CreateTicketBindingModel model)
        {
            var reservation = this.DbContext.Reservations.FirstOrDefault(r => r.Id == model.ReservationId);

            if (reservation == null)
            {
                return new ReservationSummary(false, $"No reservation with Id {model.ReservationId}");
            }

            if (reservation.IsCanceled)
            {
                return new ReservationSummary(false, $"Reservation is canceled");
            }

            var hasTicketForReservation = this.DbContext.Tickets.Any(t => t.ReservationId == model.ReservationId);

            if (hasTicketForReservation)
            {
                return new ReservationSummary(false, $"Reservation is already used");
            }

            var projection = this.DbContext.Projections.First(p => p.Id == reservation.ProjectionId);

            if (projection.StartDate < DateTime.UtcNow.AddMinutes(MINUTES_BEFORE_PROJECTION))
            {
                return new ReservationSummary(false, $"To late for reservation for projection with start date {projection.StartDate}");
            }

            Ticket newTicket = new Ticket();
            newTicket.ProjectionId = projection.Id;
            newTicket.ReservationId = reservation.Id;
            newTicket.Row = model.Row;
            newTicket.Column = model.Column;

            int rowsAffected = await this.DbContext.SaveChangesAsync();

            if (rowsAffected == 0)
            {
                return new ReservationSummary(false, $"Ticket sell server error");
            }

            projection.AvailableSeatsCount -= 1;

            return new ActionSummary(true);
        }
    }
}
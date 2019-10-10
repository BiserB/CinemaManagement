using CM.Data;
using CM.Entities;
using CM.Services.Contracts;
using CM.Services.Dtos;
using CM.Services.InputModels;
using System;
using System.Linq;

namespace CM.Services
{
    public class ReservationService : BaseService
    {
        public ReservationService(CinemaDbContext dbContext)
            : base(dbContext)
        {
        }

        public ReservationSummary MakeReservation(ReservationModel model)
        {
            var projection = this.DbContext.Projections.FirstOrDefault(p => p.Id == model.ProjectionId);

            if (projection == null)
            {
                return new ReservationSummary(false, $"Projection with id {model.ProjectionId} does not exist");
            }

            bool isStarted = projection.StartDate < DateTime.UtcNow;
            bool isToLate = projection.StartDate < DateTime.UtcNow.AddMinutes(10);

            if (isStarted || isToLate)
            {
                return new ReservationSummary(false, $"Reservation for this projection are closed");
            }

            var room = this.DbContext.Rooms.FirstOrDefault(r => r.Id == projection.RoomId);

            bool isValidRow = model.Row > 0 && model.Row <= room.Rows;
            bool isValidRColumn = model.Column > 0 && model.Column <= room.SeatsPerRow;

            if (!isValidRow || !isValidRColumn)
            {
                return new ReservationSummary(false, $"Invalid seat place");
            }

            bool isReserved = this.DbContext.Reservations.Where(r => r.ProjectionId == model.ProjectionId)
                                                          .FirstOrDefault(r => r.Row == model.Row && r.Column == model.Column)
                                                          .Equals(null);

            bool isSold = this.DbContext.Tickets.Where(t => t.ProjectionId == model.ProjectionId)
                                                .FirstOrDefault(r => r.Row == model.Row && r.Column == model.Column)
                                                .Equals(null);

            if (isReserved || isSold)
            {
                return new ReservationSummary(false, $"The place is occupied");
            }

            Reservation newReservation = new Reservation();
            newReservation.ProjectionId = projection.Id;
            newReservation.Row = model.Row;
            newReservation.Column = model.Column;

            this.DbContext.Reservations.Add(newReservation);

            int rowsAffected = this.DbContext.SaveChanges();

            if (rowsAffected == 0)
            {
                return new ReservationSummary(false, $"Reservation server error");
            }

            var movie = this.DbContext.Movies.First(m => m.Id == projection.MovieId);
            var cinema = this.DbContext.Cinemas.First(c => c.Id == room.CinemaId);

            ReservationTicket reservationTicket = new ReservationTicket();
            reservationTicket.ReservationId = newReservation.Id;
            reservationTicket.StartDate = projection.StartDate;
            reservationTicket.MovieName = movie.Name;
            reservationTicket.CinemaName = cinema.Name;
            reservationTicket.RoomNumber = room.Number;
            reservationTicket.Row = newReservation.Row;
            reservationTicket.Column = newReservation.Column;

            return new ReservationSummary(true, reservationTicket);
        }

        public ActionSummary Cancel(int id)
        {
            var reservation = this.DbContext.Reservations.FirstOrDefault(r => r.Id == id);

            if (reservation == null)
            {
                return new ActionSummary(false, $"No reservation with Id {id}");
            }

            reservation.IsCanceled = true;

            var projection = this.DbContext.Projections.First(p => p.Id == reservation.ProjectionId);

            projection.AvailableSeatsCount += 1;

            this.DbContext.SaveChanges();

            return new ActionSummary(true);
        }

        public object GetById(long id)
        {
            var reservation = this.DbContext.Reservations.FirstOrDefault(r => r.Id == id);

            return this.MapToDto(reservation);
        }

        private ReservationDto MapToDto(Reservation reservation)
        {
            if (reservation == null)
            {
                return null;
            }

            var dto = new ReservationDto();
            dto.Id = reservation.Id;
            dto.Row = reservation.Row;
            dto.Column = reservation.Column;
            return dto;
        }
    }
}
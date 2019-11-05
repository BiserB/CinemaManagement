using System;

namespace CM.Common.ResultModels
{
    public class ReservationTicket
    {
        public long ReservationId { get; set; }

        public DateTime StartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}
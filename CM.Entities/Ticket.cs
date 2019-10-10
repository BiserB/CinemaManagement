namespace CM.Entities
{
    public class Ticket
    {
        public Ticket()
        {
        }

        public long Id { get; set; }

        public long ProjectionId { get; set; }

        public Projection Projection { get; set; }

        public long? ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }

        public decimal Price { get; set; }
    }
}
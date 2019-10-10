namespace CM.Services.InputModels
{
    public class TicketModel
    {
        public long ProjectionId { get; set; }

        public long ReservationId { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}
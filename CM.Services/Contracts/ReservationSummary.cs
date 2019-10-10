namespace CM.Services.Contracts
{
    public class ReservationSummary : ActionSummary
    {
        public ReservationSummary(bool isSuccesfull, string message)
            : base(isSuccesfull, message)
        {
        }

        public ReservationSummary(bool isSuccesfull, ReservationTicket reservationTicket)
            : base(isSuccesfull)
        {
            this.ReservationTicket = reservationTicket;
        }

        public ReservationTicket ReservationTicket { get; }
    }
}
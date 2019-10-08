using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Contracts
{
    public class ReservationSummary : ActionSummary
    {
        public ReservationSummary(bool isCreated, string message) 
            : base(isCreated, message)
        {
        }

        public ReservationSummary(bool isCreated, ReservationTicket reservationTicket)
            : base(isCreated)
        {
            this.ReservationTicket = reservationTicket;
        }

        public ReservationTicket ReservationTicket { get; }
    }
}

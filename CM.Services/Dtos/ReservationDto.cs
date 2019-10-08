using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Dtos
{
    public class ReservationDto
    {
        public long Id { get; set; }

        public long ProjectionId { get; set; }
        
        public short Row { get; set; }

        public short Column { get; set; }
    }
}

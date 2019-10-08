using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.InputModels
{
    public class ReservationModel
    {
        public int ProjectionId { get; set; }
        
        public short Row { get; set; }

        public short Column { get; set; }
    }
}

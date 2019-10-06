using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Dtos
{
    public class ProjectionDto
    {
        public long Id { get; set; }

        public int RoomId { get; set; }
        
        public int MovieId { get; set; }
        
        public DateTime StartDate { get; set; }

        public int AvailableSeatsCount { get; set; }
    }
}

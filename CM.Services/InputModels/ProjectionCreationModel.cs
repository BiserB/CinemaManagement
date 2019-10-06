using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.InputModels
{
    public class ProjectionCreationModel
    {
        public int RoomId { get; set; }

        public int MovieId { get; set; }

        public DateTime StartDate { get; set; }
    }
}

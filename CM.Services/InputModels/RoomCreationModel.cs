using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.InputModels
{
    public class RoomCreationModel
    {
        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }

        public int CinemaId { get; set; }
    }
}

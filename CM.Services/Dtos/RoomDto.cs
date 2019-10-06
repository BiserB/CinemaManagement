using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }

        public int CinemaId { get; set; }
    }
}

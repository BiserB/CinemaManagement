using CM.Services.Dtos;
using CM.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Contracts
{
    public interface IRoomService
    {
        RoomDto GetById(int id);

        RoomDto GetByCinemaAndNumber(int cinemaId, int number);

        void Insert(RoomCreationModel room);
    }
}

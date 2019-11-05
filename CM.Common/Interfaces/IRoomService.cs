using CM.Common.BindingModels;
using CM.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Common.Interfaces
{
    public interface IRoomService
    {
        RoomDto GetById(int id);

        RoomDto GetByCinemaAndNumber(int cinemaId, int number);

        Task<bool> Insert(CreateRoomBindingModel model);
    }
}

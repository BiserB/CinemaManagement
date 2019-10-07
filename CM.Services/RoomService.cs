using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Data;
using CM.Entities;
using CM.Services.Dtos;
using CM.Services.InputModels;

namespace CM.Services
{
    public class RoomService : BaseService
    {
        public RoomService(CinemaDbContext dbContext) 
            : base(dbContext)
        {
        }

        public RoomDto GetByCinemaAndNumber(int cinemaId, int number)
        {
            var room = this.DbContext.Rooms.FirstOrDefault(r => r.CinemaId == cinemaId && r.Number == number);

            return this.MapToDto(room);
        }

        public RoomDto GetById(int id)
        {
            var room = this.DbContext.Rooms.FirstOrDefault(x => x.Id == id);

            return this.MapToDto(room);
        }

        public bool Insert(RoomCreationModel model)
        {
            Room newRoom = new Room(model.Number, model.SeatsPerRow, model.Rows, model.CinemaId);

            this.DbContext.Rooms.Add(newRoom);

            int result = this.DbContext.SaveChanges();

            return result == 1;
        }

        private RoomDto MapToDto(Room room)
        {
            if (room == null)
            {
                return null;
            }

            var dto = new RoomDto();

            dto.Id = room.Id;
            dto.CinemaId = room.CinemaId;
            dto.Number = room.Number;
            dto.Rows = room.Rows;
            dto.SeatsPerRow = room.SeatsPerRow;

            return dto;
        }
    }
}

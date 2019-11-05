using CM.Common.BindingModels;
using CM.Common.DTOs;
using CM.Common.Interfaces;
using CM.Data;
using CM.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(CinemaDbContext dbContext)
            : base(dbContext)
        {
        }

        public RoomDto GetById(int id)
        {
            var room = this.DbContext.Rooms.FirstOrDefault(x => x.Id == id);

            return this.MapToDto(room);
        }

        public RoomDto GetByCinemaAndNumber(int cinemaId, int number)
        {
            var room = this.DbContext.Rooms.FirstOrDefault(r => r.CinemaId == cinemaId && r.Number == number);

            return this.MapToDto(room);
        }        

        public async Task<bool> Insert(CreateRoomBindingModel model)
        {
            Room newRoom = new Room(model.Number, model.SeatsPerRow, model.Rows, model.CinemaId);

            this.DbContext.Rooms.Add(newRoom);

            int rowsAffected = await this.DbContext.SaveChangesAsync();

            return rowsAffected == 1;
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
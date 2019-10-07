using CM.Data;
using CM.Entities;
using CM.Services.Dtos;
using CM.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services
{
    public class ProjectionService : BaseService
    {
        public ProjectionService(CinemaDbContext dbContext)
            : base(dbContext)
        {
        }

        public ProjectionDto GetById(int id)
        {
            var projection = this.DbContext.Projections.FirstOrDefault(p => p.Id == id);
            
            return this.MapToDto(projection);
        }

        public ProjectionDto Get(int movieId, int roomId, DateTime startDate)
        {
            var projection = this.DbContext.Projections.FirstOrDefault(p => p.MovieId == movieId &&
                                                      p.RoomId == roomId &&
                                                      p.StartDate == startDate);

            return this.MapToDto(projection);
        }

        public IEnumerable<ProjectionDto> GetActiveProjections(int roomId)
        {
            DateTime now = DateTime.UtcNow;

            var projections = this.DbContext.Projections.Where(x => x.RoomId == roomId &&
                                             x.StartDate > now).ToList();

            var dtos = projections.Select(p => this.MapToDto(p));

            return dtos;
        }

        public bool Insert(ProjectionCreationModel model)
        {
            var room = this.DbContext.Rooms.FirstOrDefault(r => r.Id == model.RoomId);

            if(room == null)
            {
                return false;
            }

            int availableSeats = room.Rows * room.SeatsPerRow;

            var movie = this.DbContext.Movies.FirstOrDefault(m => m.Id == model.MovieId);

            if(movie == null)
            {
                return false;
            }

            bool isPastDate = DateTime.Compare(model.StartDate, DateTime.UtcNow) < 0;

            if (isPastDate)
            {
                return false;
            }

            Projection newProj = new Projection(movie.Id, room.Id, model.StartDate, availableSeats);

            this.DbContext.Projections.Add(newProj);

            int result = this.DbContext.SaveChanges();

            return result == 1;
        }

        private ProjectionDto MapToDto(Projection projection)
        {
            if (projection == null)
            {
                return null;
            }

            var dto = new ProjectionDto();

            dto.Id = projection.Id;
            dto.MovieId = projection.MovieId;
            dto.RoomId = projection.RoomId;
            dto.StartDate = projection.StartDate;

            return dto;
        }
    }
}

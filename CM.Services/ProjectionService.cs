using CM.Data;
using CM.Entities;
using CM.Models.BindingModels;
using CM.Models.DTOs;
using CM.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Services
{
    public class ProjectionService : BaseService, IProjectionService
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

        public ProjectionDto GetByModel(CreateProjectionBindingModel model)
        {
            var projection = this.DbContext.Projections.FirstOrDefault(p => p.MovieId == model.MovieId &&
                                                      p.RoomId == model.RoomId &&
                                                      p.StartDate == model.StartDate);

            return this.MapToDto(projection);
        }

        public IEnumerable<ProjectionDto> GetAllUnstarted()
        {
            DateTime now = DateTime.UtcNow;

            var projections = this.DbContext.Projections
                                            .Where(p => p.StartDate > now)
                                            .AsEnumerable()
                                            .Select(p => this.MapToDto(p));
            return projections;
        }

        public ProjectionDto GetRoomActiveProjection(int roomId)
        {
            DateTime startDate = DateTime.UtcNow.AddDays(-2);

            var activeProjection = this.DbContext.Projections
                                            .Where(p => p.RoomId == roomId && p.StartDate > startDate)
                                            .OrderBy(p => p.StartDate)
                                            .FirstOrDefault();

            if (activeProjection == null)
            {
                return null;
            }

            int durationMinutes = this.DbContext.Movies.First(m => m.Id == activeProjection.MovieId).DurationMinutes;

            bool isActive = activeProjection.StartDate.AddMinutes(durationMinutes) > DateTime.UtcNow;

            if (!isActive)
            {
                return null;
            }

            return this.MapToDto(activeProjection);
        }

        public ProjectionDto GetRoomNextProjection(int roomId)
        {
            DateTime startDate = DateTime.UtcNow;

            var nextProjection = this.DbContext.Projections
                                            .Where(p => p.RoomId == roomId && p.StartDate > startDate)
                                            .OrderBy(p => p.StartDate)
                                            .FirstOrDefault();

            if (nextProjection == null)
            {
                return null;
            }

            return this.MapToDto(nextProjection);
        }

        public async Task<ActionSummary> Insert(CreateProjectionBindingModel model)
        {
            var room = this.DbContext.Rooms.FirstOrDefault(r => r.Id == model.RoomId);

            if (room == null)
            {
                return new ActionSummary(false, $"Room with id {model.RoomId} does not exist");
            }

            var movie = this.DbContext.Movies.FirstOrDefault(m => m.Id == model.MovieId);

            if (movie == null)
            {
                return new ActionSummary(false, $"Movie with id {model.MovieId} does not exist");
            }

            bool isPastDate = DateTime.Compare(model.StartDate, DateTime.UtcNow) < 0;

            if (isPastDate)
            {
                return new ActionSummary(false, "Projection starts in the past");
            }

            var activeProjection = this.GetRoomActiveProjection(room.Id);
            var modelProjectionEndTime = model.StartDate.AddMinutes(movie.DurationMinutes);

            if (activeProjection != null)
            {
                var activeMovie = this.DbContext.Movies.First(m => m.Id == activeProjection.MovieId);

                bool isFreeTimeSlot = activeProjection.StartDate.AddMinutes(activeMovie.DurationMinutes) < model.StartDate;

                if (!isFreeTimeSlot)
                {
                    return new ActionSummary(false, $"Projection overlaps with previous one: {activeMovie.Name} at {activeProjection.StartDate}");
                }
            }

            var nextProjection = this.GetRoomNextProjection(room.Id);

            if (nextProjection != null)
            {
                var nextMovie = this.DbContext.Movies.First(m => m.Id == nextProjection.MovieId);

                var nextProjectionEndTime = nextProjection.StartDate.AddMinutes(nextMovie.DurationMinutes);

                bool isFreeTimeSlot = nextProjection.StartDate > modelProjectionEndTime || nextProjectionEndTime < model.StartDate;

                if (!isFreeTimeSlot)
                {
                    return new ActionSummary(false, $"Projection overlaps with next one: {nextMovie.Name} at {nextProjection.StartDate}");
                }
            }

            int availableSeats = room.Rows * room.SeatsPerRow;

            Projection newProj = new Projection(movie.Id, room.Id, model.StartDate, availableSeats);

            this.DbContext.Projections.Add(newProj);

            int rowsAffected = await this.DbContext.SaveChangesAsync();

            if (rowsAffected == 0)
            {
                return new ReservationSummary(false, $"Reservation server error");
            }

            int ms = CancelationService.CalculateDelay(newProj.StartDate);

            Task.Run(() => { CancelationService.DelayCancelation(ms, newProj.Id); });

            return new ActionSummary(true);
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
            dto.AvailableSeatsCount = projection.AvailableSeatsCount;

            return dto;
        }
    }
}
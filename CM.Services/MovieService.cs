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
    public class MovieService : BaseService
    {
        public MovieService(CinemaDbContext dbContext) 
            : base(dbContext)
        {
        }

        public MovieDto GetById(int id)
        {
            var movie = this.DbContext.Movies.FirstOrDefault(m => m.Id == id);
            
            return this.MapToDto(movie);
        }

        public MovieDto GetByNameAndDuration(string name, short duration)
        {
            var movie = this.DbContext.Movies.FirstOrDefault(x => x.Name == name && x.DurationMinutes == duration);
            
            return this.MapToDto(movie);
        }

        public bool Insert(MovieCreationModel model)
        {
            Movie newMovie = new Movie(model.Name, model.DurationMinutes);

            this.DbContext.Movies.Add(newMovie);

            var rowsAffected = this.DbContext.SaveChanges();

            return rowsAffected == 1;
        }

        private MovieDto MapToDto(Movie movie)
        {
            if(movie == null)
            {
                return null;
            }

            var dto = new MovieDto();

            dto.Id = movie.Id;
            dto.Name = dto.Name;
            dto.DurationMinutes = dto.DurationMinutes;

            return dto;
        }
    }
}

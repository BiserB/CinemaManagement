using CM.Data;
using CM.Entities;
using CM.Models.BindingModels;
using CM.Models.DTOs;
using CM.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Services
{
    public class MovieService : BaseService, IMovieService
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

        public async Task<bool> Insert(CreateMovieBindingModel model)
        {
            Movie newMovie = new Movie(model.Name, model.DurationMinutes);

            this.DbContext.Movies.Add(newMovie);

            var rowsAffected = await this.DbContext.SaveChangesAsync();

            return rowsAffected == 1;
        }

        private MovieDto MapToDto(Movie movie)
        {
            if (movie == null)
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
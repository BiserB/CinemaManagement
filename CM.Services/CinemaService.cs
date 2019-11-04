using CM.Data;
using CM.Entities;
using CM.Services.Contracts;
using CM.Models.BindingModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Models.DTOs;

namespace CM.Services
{
    public class CinemaService : BaseService, ICinemaService
    {
        public CinemaService(CinemaDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> CreateCinema(CreateCinemaBindingModel model)
        {
            Cinema newCinema = new Cinema(model.Name, model.Address);

            this.DbContext.Cinemas.Add(newCinema);

            var rowsAffected = await this.DbContext.SaveChangesAsync();

            return rowsAffected == 1;
        }

        public CinemaDto GetById(int id)
        {
            var cinema = this.DbContext.Cinemas.FirstOrDefault(c => c.Id == id);

            return this.MapToDto(cinema);
        }

        public List<CinemaDto> GetCinemaList()
        {
            var cinemaList = this.DbContext.Cinemas
                                .AsEnumerable()
                                .Select(c => this.MapToDto(c))
                                .ToList();

            return cinemaList;
        }

        public CinemaDto GetByNameAndAddress(string name, string address)
        {
            var cinema = this.DbContext.Cinemas.Where(x => x.Name == name && x.Address == address)
                             .FirstOrDefault();

            return this.MapToDto(cinema);
        }

        private CinemaDto MapToDto(Cinema cinema)
        {
            if (cinema == null)
            {
                return null;
            }

            var dto = new CinemaDto();
            dto.Id = cinema.Id;
            dto.Name = cinema.Name;
            dto.Address = cinema.Address;
            return dto;
        }
    }
}
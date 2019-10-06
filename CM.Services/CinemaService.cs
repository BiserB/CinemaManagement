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
    public class CinemaService
    {
        private readonly CinemaDbContext db;

        public CinemaService(CinemaDbContext dbContext)
        {
            this.db = dbContext;
        }

        public bool CreateCinema(CinemaCreationModel model)
        {
            Cinema newCinema = new Cinema(model.Name, model.Address);

            db.Cinemas.Add(newCinema);

            var rowsAffected = db.SaveChanges();

            return rowsAffected == 1;
        }

        public CinemaDto GetByNameAndAddress(string name, string address)
        {
            var cinema = db.Cinemas.Where(x => x.Name == name && x.Address == address)
                             .FirstOrDefault();

            if(cinema != null)
            {
                var dto = new CinemaDto();
                dto.Id = cinema.Id;
                dto.Name = cinema.Name;
                dto.Address = cinema.Address;
                return dto;
            }

            return null;
        }

    }
}

﻿using CM.Data;
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
    public class CinemaService : BaseService
    {
        public CinemaService(CinemaDbContext dbContext)
            : base(dbContext)
        {
        }

        public bool CreateCinema(CinemaCreationModel model)
        {
            Cinema newCinema = new Cinema(model.Name, model.Address);

            this.DbContext.Cinemas.Add(newCinema);

            var rowsAffected = this.DbContext.SaveChanges();

            return rowsAffected == 1;
        }

        public CinemaDto GetByNameAndAddress(string name, string address)
        {
            var cinema = this.DbContext.Cinemas.Where(x => x.Name == name && x.Address == address)
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
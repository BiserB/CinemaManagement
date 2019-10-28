using CM.Services.Dtos;
using CM.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Contracts
{
    public interface ICinemaService
    {
        CinemaDto GetById(int id);

        List<CinemaDto> GetCinemaList();

        CinemaDto GetByNameAndAddress(string name, string address);

        Task<bool> CreateCinema(CinemaCreationModel model);
    }
}

using CM.Models.BindingModels;
using CM.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Services.Contracts
{
    public interface ICinemaService
    {
        CinemaDto GetById(int id);

        List<CinemaDto> GetCinemaList();

        CinemaDto GetByNameAndAddress(string name, string address);

        Task<bool> CreateCinema(CreateCinemaBindingModel model);
    }
}

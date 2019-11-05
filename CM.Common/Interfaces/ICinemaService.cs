
using CM.Common.BindingModels;
using CM.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Common.Interfaces
{ 
    public interface ICinemaService
    {
        CinemaDto GetById(int id);

        List<CinemaDto> GetCinemaList();

        CinemaDto GetByNameAndAddress(string name, string address);

        Task<bool> CreateCinema(CreateCinemaBindingModel model);
    }
}

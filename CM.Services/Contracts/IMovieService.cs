using CM.Models.BindingModels;
using CM.Models.DTOs;
using System.Threading.Tasks;

namespace CM.Services.Contracts
{
    public interface IMovieService
    {
        MovieDto GetById(int id);

        MovieDto GetByNameAndDuration(string name, short duration);

        Task<bool> Insert(CreateMovieBindingModel model);
    }
}

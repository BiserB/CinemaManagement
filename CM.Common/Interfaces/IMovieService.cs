
using CM.Common.BindingModels;
using CM.Common.DTOs;
using System.Threading.Tasks;

namespace CM.Common.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetById(int id);

        MovieDto GetByNameAndDuration(string name, short duration);

        Task<bool> Insert(CreateMovieBindingModel model);
    }
}

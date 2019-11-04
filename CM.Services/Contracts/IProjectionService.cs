using CM.Models.BindingModels;
using CM.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Services.Contracts
{
    public interface IProjectionService
    {
        ProjectionDto GetById(int id);

        ProjectionDto GetByModel(CreateProjectionBindingModel model);

        IEnumerable<ProjectionDto> GetAllUnstarted();

        ProjectionDto GetRoomActiveProjection(int roomId);

        ProjectionDto GetRoomNextProjection(int roomId);

        Task<ActionSummary> Insert(CreateProjectionBindingModel model);
    }
}


using CM.Common.BindingModels;
using CM.Common.DTOs;
using CM.Common.ResultModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Common.Interfaces
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

using System;

namespace CM.Services.InputModels
{
    public class ProjectionCreationModel
    {
        public int RoomId { get; set; }

        public int MovieId { get; set; }

        public DateTime StartDate { get; set; }
    }
}
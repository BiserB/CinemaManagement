using System;

namespace CM.Models.BindingModels
{
    public class CreateProjectionBindingModel
    {
        public int RoomId { get; set; }

        public int MovieId { get; set; }

        public DateTime StartDate { get; set; }
    }
}
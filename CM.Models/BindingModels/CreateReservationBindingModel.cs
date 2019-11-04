namespace CM.Models.BindingModels
{
    public class CreateReservationBindingModel
    {
        public long ProjectionId { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}
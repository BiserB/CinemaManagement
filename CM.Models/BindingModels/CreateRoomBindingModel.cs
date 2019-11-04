namespace CM.Models.BindingModels
{
    public class CreateRoomBindingModel
    {
        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }

        public int CinemaId { get; set; }
    }
}
namespace CM.Services.InputModels
{
    public class RoomCreationModel
    {
        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }

        public int CinemaId { get; set; }
    }
}
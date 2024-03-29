﻿namespace CM.Entities
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public long Id { get; set; }

        public long ProjectionId { get; set; }

        public Projection Projection { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }

        public bool IsCanceled { get; set; }
    }
}
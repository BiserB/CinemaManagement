﻿using System;

namespace CM.Common.DTOs
{
    public class ProjectionDto
    {
        public long Id { get; set; }

        public int RoomId { get; set; }

        public int MovieId { get; set; }

        public DateTime StartDate { get; set; }

        public int AvailableSeatsCount { get; set; }
    }
}
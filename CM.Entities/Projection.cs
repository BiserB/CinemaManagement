using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Entities
{
    public class Projection
    {
        public Projection()
        {

        }
        public Projection(int movieId, int roomId, DateTime startdate, int availableSeats)
            :this()
        {
            this.MovieId = movieId;
            this.RoomId = roomId;
            this.StartDate = startdate;
            this.AvailableSeatsCount = availableSeats;
            this.Reservations = new List<Reservation>();
        }

        public long Id { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public DateTime StartDate { get; set; }

        public List<Reservation> Reservations { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Available seats count cannot be negative")]
        public int AvailableSeatsCount { get; set; }
    }
}

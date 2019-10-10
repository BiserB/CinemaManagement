using System.Collections.Generic;

namespace CM.Entities
{
    public class Movie
    {
        public Movie()
        {
            this.Projections = new List<Projection>();
        }

        public Movie(string name, short durationInMinutes)
            : this()
        {
            this.Name = name;
            this.DurationMinutes = durationInMinutes;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public short DurationMinutes { get; set; }

        public virtual ICollection<Projection> Projections { get; set; }
    }
}
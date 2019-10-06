using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Entities
{
    public class Movie
    {
        public Movie()
        {
            this.Projections = new List<Projection>();
        }

        public Movie(string name, short durationInMinutes)
            :this()
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

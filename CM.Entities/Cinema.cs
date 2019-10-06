using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Entities
{
    public class Cinema
    {
        public Cinema()
        {
            this.Rooms = new List<Room>();
        }

        public Cinema(string name, string address)
            :this()
        {
            this.Name = name;
            this.Address = address;            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}

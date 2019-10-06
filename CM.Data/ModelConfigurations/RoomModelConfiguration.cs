using CM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Data.ModelConfigurations
{
    internal sealed class RoomModelConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomModelConfiguration()
        {
            this.HasKey(r => r.Id);
            this.Property(r => r.Number).IsRequired();
            this.Property(r => r.Rows).IsRequired();
            this.Property(r => r.SeatsPerRow).IsRequired();
            this.Property(r => r.CinemaId).IsRequired();
        }        
    }
}

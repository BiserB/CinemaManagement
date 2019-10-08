using CM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Data.ModelConfigurations
{
    internal sealed class ReservationModelConfiguration : EntityTypeConfiguration<Reservation>
    {
        public ReservationModelConfiguration()
        {
            this.HasKey(r => r.Id);
            this.HasRequired(r => r.Projection)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.ProjectionId);
        }
    }
}

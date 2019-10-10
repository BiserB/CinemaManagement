using CM.Entities;
using System.Data.Entity.ModelConfiguration;

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
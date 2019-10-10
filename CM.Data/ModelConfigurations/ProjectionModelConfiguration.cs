using CM.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CM.Data.ModelConfigurations
{
    internal sealed class ProjectionModelConfiguration : EntityTypeConfiguration<Projection>
    {
        public ProjectionModelConfiguration()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.MovieId).IsRequired();
            this.Property(p => p.RoomId).IsRequired();
            this.Property(p => p.StartDate).IsRequired();
            this.Property(p => p.StartDate).IsRequired();

            this.Property(p => p.AvailableSeatsCount).IsRequired();
        }
    }
}
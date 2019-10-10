using CM.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CM.Data.ModelConfigurations
{
    internal sealed class MovieModelConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieModelConfiguration()
        {
            this.HasKey(m => m.Id);
            this.Property(m => m.Name).IsRequired();
            this.Property(m => m.DurationMinutes).IsRequired();
        }
    }
}
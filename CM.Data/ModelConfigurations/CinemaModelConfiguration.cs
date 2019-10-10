using CM.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CM.Data.ModelConfigurations
{
    internal sealed class CinemaModelConfiguration : EntityTypeConfiguration<Cinema>
    {
        public CinemaModelConfiguration()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired();
            this.Property(model => model.Address).IsRequired();
        }
    }
}
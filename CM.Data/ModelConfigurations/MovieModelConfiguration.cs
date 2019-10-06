using CM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

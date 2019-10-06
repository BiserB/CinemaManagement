
using CM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

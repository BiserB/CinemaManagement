using CM.Data.MigrationConfigurations;
using CM.Data.ModelConfigurations;
using CM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
            : base("CinemaDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CinemaDbContext, MigrationConfiguration>());
        }

        public virtual IDbSet<Cinema> Cinemas { get; set; }
        public virtual IDbSet<Room> Rooms { get; set; }
        public virtual IDbSet<Movie> Movies { get; set; }
        public virtual IDbSet<Projection> Projections { get; set; }
        public virtual IDbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CinemaModelConfiguration());
            modelBuilder.Configurations.Add(new MovieModelConfiguration());
            modelBuilder.Configurations.Add(new ProjectionModelConfiguration());
            modelBuilder.Configurations.Add(new RoomModelConfiguration());
            modelBuilder.Configurations.Add(new ReservationModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

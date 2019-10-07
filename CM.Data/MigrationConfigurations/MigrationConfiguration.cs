using CM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Data.MigrationConfigurations
{
    public class MigrationConfiguration : DbMigrationsConfiguration<CinemaDbContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CinemaDbContext context)
        {
            context.Cinemas.AddOrUpdate(c => c.Id,
                new Cinema() { Id = 1, Name = "CineMax", Address = "MOL1" },
                new Cinema() { Id = 2, Name = "CineGrand", Address = "MOL2" },
                new Cinema() { Id = 3, Name = "Arena", Address = "MOL3" }
                );

            context.Rooms.AddOrUpdate(r => r.Id,
                new Room() { Id = 1, CinemaId = 1, Number = 101, Rows = 5, SeatsPerRow = 20 },
                new Room() { Id = 2, CinemaId = 1, Number = 102, Rows = 25, SeatsPerRow = 30 },
                new Room() { Id = 3, CinemaId = 1, Number = 103, Rows = 16, SeatsPerRow = 22 },
                new Room() { Id = 4, CinemaId = 2, Number = 1, Rows = 8, SeatsPerRow = 20 },
                new Room() { Id = 5, CinemaId = 2, Number = 2, Rows = 10, SeatsPerRow = 14 },
                new Room() { Id = 6, CinemaId = 3, Number = 1, Rows = 15, SeatsPerRow = 25 },
                new Room() { Id = 7, CinemaId = 3, Number = 2, Rows = 15, SeatsPerRow = 25 }
                );

            context.Movies.AddOrUpdate(m => m.Id,
                new Movie() { Id = 1, Name = "Avengers: Infinity War", DurationMinutes = 149 },
                new Movie() { Id = 2, Name = "Deadpool 2", DurationMinutes = 119 },
                new Movie() { Id = 3, Name = "Jurassic World: Fallen Kingdom", DurationMinutes = 128 },
                new Movie() { Id = 4, Name = "Avengers: Infinity War", DurationMinutes = 149 },
                new Movie() { Id = 5, Name = "The Incredibles 2", DurationMinutes = 118 }
                );

            context.Projections.AddOrUpdate(m => m.Id,
                new Projection() { Id = 1, MovieId = 5, RoomId = 1, AvailableSeatsCount = 12, StartDate = DateTime.Now.AddDays(2)},
                new Projection() { Id = 2, MovieId = 5, RoomId = 2, AvailableSeatsCount = 220, StartDate = DateTime.Now.AddDays(1)},
                new Projection() { Id = 3, MovieId = 1, RoomId = 3, AvailableSeatsCount = 144, StartDate = DateTime.Now.AddHours(1)},                
                new Projection() { Id = 4, MovieId = 2, RoomId = 4, AvailableSeatsCount = 90, StartDate = DateTime.Now.AddHours(1)},                
                new Projection() { Id = 5, MovieId = 3, RoomId = 6, AvailableSeatsCount = 55, StartDate = DateTime.Now},                
                new Projection() { Id = 6, MovieId = 2, RoomId = 6, AvailableSeatsCount = 245, StartDate = DateTime.Now.AddDays(1)}              
                );
        }
    }
}

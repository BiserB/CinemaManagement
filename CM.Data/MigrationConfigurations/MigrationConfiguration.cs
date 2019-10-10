using System.Data.Entity.Migrations;

namespace CM.Data.MigrationConfigurations
{
    public class MigrationConfiguration : DbMigrationsConfiguration<CinemaDbContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        //protected override void Seed(CinemaDbContext context)
        //{
        //    context.Cinemas.AddOrUpdate(c => c.Id,
        //        new Cinema() { Id = 1, Name = "CineMax", Address = "Sofia MOL1" },
        //        new Cinema() { Id = 2, Name = "CineGrand", Address = "Plovdiv MOL" },
        //        new Cinema() { Id = 3, Name = "Arena", Address = "Sofia MOL3" }
        //        );

        //    context.Rooms.AddOrUpdate(r => r.Id,
        //        new Room() { Id = 1, CinemaId = 1, Number = 101, Rows = 7, SeatsPerRow = 20 },
        //        new Room() { Id = 2, CinemaId = 1, Number = 102, Rows = 25, SeatsPerRow = 30 },
        //        new Room() { Id = 3, CinemaId = 1, Number = 103, Rows = 16, SeatsPerRow = 22 },
        //        new Room() { Id = 4, CinemaId = 2, Number = 1, Rows = 8, SeatsPerRow = 20 },
        //        new Room() { Id = 5, CinemaId = 2, Number = 2, Rows = 10, SeatsPerRow = 14 },
        //        new Room() { Id = 6, CinemaId = 3, Number = 1, Rows = 15, SeatsPerRow = 25 },
        //        new Room() { Id = 7, CinemaId = 3, Number = 2, Rows = 15, SeatsPerRow = 25 }
        //        );

        //    context.Movies.AddOrUpdate(m => m.Id,
        //        new Movie() { Id = 1, Name = "Avengers: Infinity War", DurationMinutes = 149 },
        //        new Movie() { Id = 2, Name = "Deadpool 2", DurationMinutes = 119 },
        //        new Movie() { Id = 3, Name = "Jurassic World: Fallen Kingdom", DurationMinutes = 128 },
        //        new Movie() { Id = 4, Name = "Avengers: Infinity War", DurationMinutes = 149 },
        //        new Movie() { Id = 5, Name = "The Incredibles 2", DurationMinutes = 118 }
        //        );

        //    context.Projections.AddOrUpdate(m => m.Id,
        //        new Projection() { Id = 1, MovieId = 5, RoomId = 1, AvailableSeatsCount = 140, StartDate = DateTime.UtcNow.AddDays(2) },
        //        new Projection() { Id = 2, MovieId = 5, RoomId = 2, AvailableSeatsCount = 750, StartDate = DateTime.UtcNow.AddDays(1) },
        //        new Projection() { Id = 3, MovieId = 1, RoomId = 3, AvailableSeatsCount = 352, StartDate = DateTime.UtcNow.AddHours(1) },
        //        new Projection() { Id = 4, MovieId = 2, RoomId = 4, AvailableSeatsCount = 160, StartDate = DateTime.UtcNow.AddHours(1) },
        //        new Projection() { Id = 5, MovieId = 3, RoomId = 6, AvailableSeatsCount = 375, StartDate = DateTime.UtcNow.AddDays(-1) },
        //        new Projection() { Id = 6, MovieId = 2, RoomId = 6, AvailableSeatsCount = 375, StartDate = DateTime.UtcNow.AddDays(-1) },
        //        new Projection() { Id = 7, MovieId = 2, RoomId = 6, AvailableSeatsCount = 375, StartDate = DateTime.UtcNow.AddMinutes(12) }
        //        );

        //    context.Reservations.AddOrUpdate(r => r.Id,
        //        new Reservation() { Id = 1, ProjectionId = 1, Row = 5, Column = 10, IsCanceled = false },
        //        new Reservation() { Id = 2, ProjectionId = 1, Row = 5, Column = 11, IsCanceled = false },
        //        new Reservation() { Id = 3, ProjectionId = 6, Row = 5, Column = 11, IsCanceled = true },
        //        new Reservation() { Id = 4, ProjectionId = 7, Row = 5, Column = 11, IsCanceled = false }
        //        );
        //}
    }
}
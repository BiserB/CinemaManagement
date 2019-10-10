using CM.Data;
using CM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Services
{
    public static class CancelationService
    {
        private const int CANCELATION_MINUTES = 10;

        public static async void InspectProjections()
        {
            using (var dbContext = new CinemaDbContext())
            {
                DateTime now = DateTime.UtcNow;

                List<Projection> unstartedProjections = dbContext.Projections.Where(p => p.StartDate > now).ToList();

                List<Task> tasks = new List<Task>();

                foreach (var projection in unstartedProjections)
                {
                    int miliseconds = CalculateDelay(projection.StartDate);

                    if (miliseconds != 0)
                    {
                        tasks.Add(Task.Run(() => { DelayCancelation(miliseconds, projection.Id); }));
                    }
                }

                await Task.WhenAll(tasks.ToArray());
            }
        }

        public static async void DelayCancelation(int miliseconds, long projectionId)
        {
            await Task.Delay(miliseconds);

            CancelReservations(projectionId);
        }

        public static void CancelReservations(long projectionId)
        {
            using (var db = new CinemaDbContext())
            {
                var projection = db.Projections.First(p => p.Id == projectionId);
                var reservations = db.Reservations.Where(r => r.ProjectionId == projectionId);

                foreach (var reservation in reservations)
                {
                    reservation.IsCanceled = true;
                    projection.AvailableSeatsCount += 1;
                }

                db.SaveChanges();
            }
        }

        public static int CalculateDelay(DateTime projectionStartDate)
        {
            var canncelationDate = projectionStartDate;

            canncelationDate.AddMinutes(-CANCELATION_MINUTES);

            if (canncelationDate < DateTime.UtcNow)
            {
                return 0;
            }

            var timeSpan = canncelationDate.Subtract(DateTime.UtcNow);

            return (int)timeSpan.TotalMilliseconds;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Data;
using CM.Services.Helpers;

namespace CM.Services
{
    public static class CancelationService 
    {
        public static void InspectProjections()
        {
            using (var dbContext = new CinemaDbContext())
            {
                DateTime now = DateTime.UtcNow;

                var unstartedProjections = dbContext.Projections
                                                .Where(p => p.StartDate > now)
                                                .ToList();

                foreach (var projection in unstartedProjections)
                {
                    ScheduleCancelation(projection.StartDate, projection.Id);
                }
            }            
        }

        private static async void ScheduleCancelation(DateTime projectionStartDate, long projectionId)
        {
            var canncelationDate = projectionStartDate.AddMinutes(-10);

            if (canncelationDate < DateTime.UtcNow)
            {
                return;
            }

            var timeSpan = canncelationDate.Subtract(DateTime.UtcNow);

            var delay = (int)timeSpan.TotalMilliseconds;

            await Task.Delay(delay);

            CancelReserevations(projectionId);
        }

        private static void CancelReserevations(long projectionId)
        {
            using (var db = new CinemaDbContext())
            {
                var reservations = db.Reservations.Where(r => r.ProjectionId == projectionId);

                foreach (var reservation in reservations)
                {
                    reservation.IsCanceled = true;
                }

                db.SaveChangesAsync();
            }
        }
    }
}

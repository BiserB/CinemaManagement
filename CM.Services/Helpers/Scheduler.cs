using CM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Helpers
{
    public static class Scheduler
    {
        public static async void ScheduleCancelation(DateTime projectionStartDate, long projectionId)
        {
            var canncelationDate = projectionStartDate.AddMinutes(-10);

            var timeSpan = canncelationDate.Subtract(DateTime.UtcNow);

            var delay = (int)timeSpan.TotalMilliseconds;

            await Task.Delay(delay);

            CancelReserevations(projectionId);
        }

        public static async void CancelReserevations(long projectionId)
        {
            using (var db = new CinemaDbContext())
            {
                var reservations = db.Reservations.Where(r => r.ProjectionId == projectionId);

                foreach (var reservation in reservations)
                {

                }
            }
        }
    }
}

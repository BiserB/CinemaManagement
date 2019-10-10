using CM.Data;

namespace CM.Services
{
    public abstract class BaseService
    {
        public BaseService(CinemaDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public CinemaDbContext DbContext { get; set; }
    }
}
using CM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

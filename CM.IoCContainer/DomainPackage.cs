using CM.Common.Interfaces;
using CM.Data;
using CM.Services;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CM.IoCContainer
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICinemaService, CinemaService>(Lifestyle.Scoped);
            container.Register<IMovieService, MovieService>(Lifestyle.Scoped);
            container.Register<IRoomService, RoomService>(Lifestyle.Scoped);
            container.Register<IProjectionService, ProjectionService>(Lifestyle.Scoped);
            container.Register<IReservationService, ReservationService>(Lifestyle.Scoped);
            container.Register<ITicketService, TicketService>(Lifestyle.Scoped);

            container.Register<CinemaDbContext>(Lifestyle.Scoped);
        }
    }
}
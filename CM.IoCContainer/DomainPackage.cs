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
            container.Register<CinemaService, CinemaService>(Lifestyle.Scoped);
            container.Register<MovieService, MovieService>(Lifestyle.Scoped);
            container.Register<RoomService, RoomService>(Lifestyle.Scoped);
            container.Register<ProjectionService, ProjectionService>(Lifestyle.Scoped);
            container.Register<ReservationService, ReservationService>(Lifestyle.Scoped);

            container.Register<CinemaDbContext>(Lifestyle.Scoped);
        }
    }
}
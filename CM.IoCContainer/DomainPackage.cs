using CM.Data;
using CM.Services;
using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            container.Register<CinemaDbContext>(Lifestyle.Scoped);

            //container.Register<INewProjection, NewProjectionCreation>();
            //container.RegisterDecorator<INewProjection, NewProjectionMovieValidation>();
            //container.RegisterDecorator<INewProjection, NewProjectionUniqueValidation>();
            //container.RegisterDecorator<INewProjection, NewProjectionRoomValidation>();
            //container.RegisterDecorator<INewProjection, NewProjectionPreviousOverlapValidation>();
            //container.RegisterDecorator<INewProjection, NewProjectionNextOverlapValidation>();

            //throw new NotImplementedException();
        }
    }
}

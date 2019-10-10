using SimpleInjector;
using SimpleInjector.Packaging;

namespace CM.IoCContainer
{
    public class DataPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
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
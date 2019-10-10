using CM.IoCContainer;
using CM.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Packaging;
using System.Web;
using System.Web.Http;

namespace CM.App
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            IPackage[] packages = new IPackage[]
            {
                new DataPackage(),
                new DomainPackage()
            };

            foreach (IPackage package in packages)
            {
                package.RegisterServices(container);
            }

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            CancelationService.InspectProjections();
        }
    }
}
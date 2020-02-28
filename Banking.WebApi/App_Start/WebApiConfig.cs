using Banking.Business;
using Banking.Business.Contracts;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Banking.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<ICityBl, CityBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IBranchBl, BranchBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IManagerBl, ManagerBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeBl, EmployeeBl>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            container.AddNewExtension<UnityExtension>();
        }
    }
}

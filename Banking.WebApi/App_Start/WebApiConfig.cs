using Banking.Business;
using Banking.Business.Contracts;
using Banking.Business.Account;
using Banking.Business.Contracts.IAccount;
using Banking.Business.Models;
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
            container.RegisterType<IBankBl, BankBl>(new HierarchicalLifetimeManager());
            container.RegisterType<ICityBl, CityBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountBl, AccountBl>(new HierarchicalLifetimeManager());
            //container.RegisterType<ICustomerBl, CustomerBl>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            container.AddNewExtension<Banking.Business.UnityExtension>();
        }
    }
}

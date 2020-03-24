using Banking.Business;
using Banking.Business.Account;
using Banking.Business.Contracts;
using Banking.Business.Contracts.Transaction;

using Banking.Business.Models;
using Banking.Business.Contracts.IAccount;

using Banking.Business.Transaction;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using System.Web.Http.Cors;

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
            var corsAttr = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(corsAttr);
            var container = new UnityContainer();
            container.RegisterType<ICityBl, CityBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IBranchBl, BranchBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IManagerBl, ManagerBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeBl, EmployeeBl>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionTypeBl, TransactionTypeBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountBl, AccountBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountTypeBl, AccountTypeBl>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerBl, CustomerBl>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionBl, TransactionBl>(new HierarchicalLifetimeManager());
            container.RegisterType<IpaymentBl, PaymentBl>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            container.AddNewExtension<UnityExtension>();
            
        }
    }
}

using CadmusApplication;
using CadmusApplication.Interface;
using CadmusData.Repositories;
using CadmusDomain.Interfaces.Repositories;
using CadmusDomain.Interfaces.Services;
using CadmusDomain.Services;
using CommonServiceLocator;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace CadmusApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            // Application 
            container.RegisterType<IEscolaAppService, EscolaAppService>()
                .RegisterType<ITurmaAppService, TurmaAppService>(new HierarchicalLifetimeManager());

            // Domain
            container.RegisterType<IEscolaServices, EscolaService>()
                .RegisterType<ITurmaServices, TurmaService>(new HierarchicalLifetimeManager());

            // Repository
            container.RegisterType<IEscolaRepository, EscolaRepository>()
                .RegisterType<ITurmaRepository, TurmaRepository>(new HierarchicalLifetimeManager());

            // Bases
            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
            .RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>))
            .RegisterType(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));

            //var unityServiceLocator = new UnityServiceLocator(container);
            //ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
using mattresses_management_dektop_app.Core.Factories;
using mattresses_management_dektop_app.Core.Logging;
using mattresses_management_dektop_app.Core.Services;
using mattresses_management_dektop_app.Core.Services.Api;
using Microsoft.Practices.Unity;

namespace mattresses_management_dektop_app.Configurations
{
    class ServiceConfig
    {
        private readonly IUnityContainer container;
        private static readonly Log LOG = LogFactory.CreateNewIstance(typeof(RepositoriesConfig));

        public ServiceConfig(IUnityContainer container)
        {
            this.container = container;
            this.Init();
        }

        private void Init()
        {
            this.container.RegisterType<IProductsService, ProductsService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IAttributesService, AttributesService>(new ContainerControlledLifetimeManager());

            this.container.RegisterType<MattressFactory, MattressFactory>(new ContainerControlledLifetimeManager());

            this.container.RegisterType<IMattressesService, MattressesService>(new ContainerControlledLifetimeManager());

            LOG.Information("Service configuration is done.");
        }
    }
}

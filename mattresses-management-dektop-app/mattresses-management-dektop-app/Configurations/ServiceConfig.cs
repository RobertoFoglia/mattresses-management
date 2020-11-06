using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services;
using mattresses_management_dektop_app.Core.Services.Api;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mattresses_management_dektop_app.Configurations
{
    class ServiceConfig
    {
        private readonly IUnityContainer container;

        public ServiceConfig(IUnityContainer container)
        {
            this.container = container;
            this.Init();
        }

        private void Init() {
            this.container.RegisterType<IProductsService, ProductsService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IMattressesService, MattressesService>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IAttributesService, AttributesService>(new ContainerControlledLifetimeManager());
        }
    }
}

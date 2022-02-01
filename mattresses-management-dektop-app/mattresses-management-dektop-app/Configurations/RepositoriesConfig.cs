using mattresses_management_dektop_app.Core.Logging;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Repositories.SQLite;
using Microsoft.Practices.Unity;
using SQLite;

namespace mattresses_management_dektop_app.Configurations
{
    internal class RepositoriesConfig
    {
        private static readonly Log LOG = LogFactory.CreateNewIstance(typeof(RepositoriesConfig));

        private readonly SQLiteConfig _sQLiteConfig;
        private readonly IUnityContainer container;
        private readonly SQLiteConnection _sqlLiteConnection;

        public RepositoriesConfig(IUnityContainer container)
        {
            this.container = container;
            _sQLiteConfig = new SQLiteConfig();
            this._sqlLiteConnection = new SQLiteConnection(this._sQLiteConfig.DatabasePath);
            this.Init();
        }

        private void Init()
        {
            this.container.RegisterInstance<SQLiteConfig>(_sQLiteConfig);
            this.container.RegisterInstance<SQLiteConnection>(_sqlLiteConnection);

            this.container.RegisterInstance<IAttributesRepository>(new AttributesSQLiteRepository(this._sqlLiteConnection));
            this.container.RegisterInstance<IProductsRepository>(new ProductsSQLiteRepository(this._sqlLiteConnection));
            this.container.RegisterInstance<IMattressAttributesRepository>(new MattressesAttributesSQLiteRepository(this._sqlLiteConnection));
            this.container.RegisterInstance<IMattressProductsRepository>(new MattressProductsSQLiteRepository(this._sqlLiteConnection));

            this.container.RegisterType<IMattressesRepository, MattressesSQLiteRepository>(new ContainerControlledLifetimeManager());

            LOG.Information("Repositories configuration is done.");
        }
    }
}

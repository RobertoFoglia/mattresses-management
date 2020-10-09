using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Repositories.SQLite;
using Microsoft.Practices.Unity;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mattresses_management_dektop_app.Configurations
{
    class RepositoriesConfig
    {
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

        private void Init() {
            this.container.RegisterInstance<IAttributesRepository>(new AttributesSQLiteRepository(this._sqlLiteConnection));
            this.container.RegisterInstance<IMattressAttributesRepository>(new MattressesAttributesSQLiteRepository(this._sqlLiteConnection));
            this.container.RegisterInstance<IMattressesRepository>(new MattressesSQLiteRepository(this._sqlLiteConnection));
            this.container.RegisterInstance<IMattressProductsRepository>(new MattressProductsSQLiteRepository(this._sqlLiteConnection));
            this.container.RegisterInstance<IProductsRepository>(new ProductsSQLiteRepository(this._sqlLiteConnection));
        }
    }
}

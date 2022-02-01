using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System.Collections.Generic;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class ProductsSQLiteRepository : AbstractSQLiteRepository<Product, int>, IProductsRepository
    {
        public ProductsSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool)
        {
        }

        public List<Product> FindByALikeWithNameAndDescription(string name, string description)
        {
            name = '%' + name.Replace(' ', '%') + '%';
            description = '%' + description.Replace(' ', '%') + '%';
            return this.connectionPool
                .Query<Product>(
                    "SELECT * FROM " + Product.TableName +
                " WHERE  " + Product.NameOfName + " LIKE ? AND " + Product.DescriptionName + " LIKE ?",
                    name, description
                ); ;
        }
    }
}
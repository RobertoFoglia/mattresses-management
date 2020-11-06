using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class MattressProductsSQLiteRepository : AbstractSQLiteRepository<MattressProduct, int>, IMattressProductsRepository
    {
        public MattressProductsSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool)
        {
        }

        public List<Product> GetTheProductsOfTheMattresses(Mattress mattress)
        {
            return this.connectionPool.Query<Product>(
                "SELECT * FROM " + Product.TableName +
                " WHERE " + Product.KeyName + " IN (" +
                "                   SELECT " + MattressProduct.ProductKey + " FROM " + MattressProduct.TableName +
                                    " WHERE " + MattressProduct.MattressKey + "= ?" +
                                     ")",
                mattress.Id
            );
        }

        public List<MattressProduct> FindByMattress(Mattress mattress)
        {
            return this.connectionPool.Query<MattressProduct>(
                "SELECT * FROM " + MattressProduct.TableName +
                " WHERE " + MattressProduct.MattressKey + " = ?"
                , mattress.Id);
        }

        public bool BelongsToAMattress(Product entity) {
            return this.connectionPool
                .Query<MattressProduct>(
                    "SELECT * FROM " + MattressProduct.TableName +
                " WHERE " + MattressProduct.ProductKey + " = ?",
                    entity.Id
                )
                .Count > 0;
        }
    }
}

﻿using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class MattressProductsSQLiteRepository : AbstractSQLiteRepository<MattressProduct, int>, IMattressProductsRepository
    {
        public MattressProductsSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool)
        {
        }

        public List<Product> GetProductsOfTheMattresses(Mattress mattress) {
            return this.connectionPool.Query<Product>(
                "SELECT * FROM " + Product.TableName + 
                " WHERE " + Product.KeyName + " IN (" +
                "                   SELECT " + MattressProduct.ProductKey + " FROM " + MattressProduct.TableName + 
                                    " WHERE " + MattressProduct.MattressKey + "= ?" +
                                     ")",
                mattress.Id 
            );
        }
    }
}

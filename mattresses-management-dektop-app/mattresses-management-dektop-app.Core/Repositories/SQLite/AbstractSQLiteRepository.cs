using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public abstract class AbstractSQLiteRepository<E, K> : IRepository<E, K>
    {
        public SQLiteConnection connectionPool;
        public AbstractSQLiteRepository(SQLiteConnection connectionPool) {
            this.connectionPool = connectionPool;
            InitTable();
        }

        public void InitTable()
        {
            this.connectionPool.CreateTable<E>();
        }

        public T Find<T>(K key) where T : E, new()
        {
            return this.connectionPool.Find<T>(key);
        }

        public int Insert(E item) {
            return this.connectionPool.Insert(item);
        }
    }
}

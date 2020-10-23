using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public abstract class AbstractSQLiteRepository<E, K> : IRepository<E, K> where E : new()
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

        public E Find(K key)
        {
            return this.connectionPool.Find<E>(key);
        }

        public int Insert(E item) {
            return this.connectionPool.Insert(item);
        }

        public List<E> FindAll()
        {
            return this.connectionPool.Table<E>().ToList();
        }

        public int Update(E item)
        {
            return this.connectionPool.Update(item);
        }

        public int Delete(K key) {
            return this.connectionPool.Delete<K>(key);
        }

        public int Delete(E entity)
        {
            return this.connectionPool.Delete(entity);
        }
    }
}

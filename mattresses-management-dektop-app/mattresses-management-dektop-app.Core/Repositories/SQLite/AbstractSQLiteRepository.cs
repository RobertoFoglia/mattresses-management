using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public abstract class AbstractSQLiteRepository<E, K> : IRepository<E, K> where E : new()
    {
        public SQLiteConnection connectionPool;
        public AbstractSQLiteRepository(SQLiteConnection connectionPool) {
            this.connectionPool = connectionPool;
            this.InitTable();
        }

        public virtual CreateTableResult InitTable()
        {
            return this.connectionPool.CreateTable<E>();
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

        public List<E> Where(Expression<Func<E, bool>> predExpr)
        {
            return this.connectionPool.Table<E>().Where(predExpr).ToList();
        }

        public int InsertAll(List<E> items)
        {
            return this.connectionPool.InsertAll(items);
        }
    }
}

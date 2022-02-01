using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace mattresses_management_dektop_app.Core.Repositories.Api
{
    public interface IRepository<E, K> where E : new()
    {
        E Find(K key);

        int Insert(E item);

        int InsertAll(List<E> items);

        List<E> FindAll();

        int Update(E item);

        int Delete(K key);

        int Delete(E entity);

        List<E> Where(Expression<Func<E, bool>> predExpr);
    }
}
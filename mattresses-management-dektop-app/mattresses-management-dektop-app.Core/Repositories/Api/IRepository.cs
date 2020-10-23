using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.Api
{
    public interface IRepository<E, K> where E : new()
    {
        E Find(K key);

        int Insert(E item);

        List<E> FindAll();

        int Update(E item);

        int Delete(K key);

        int Delete(E entity);
    }
}

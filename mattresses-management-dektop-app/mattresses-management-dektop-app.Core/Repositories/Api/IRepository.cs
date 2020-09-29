using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.Api
{
    public interface IRepository<E, K>
    {
        T Find<T>(K key) where T : E, new();

        int Insert(E item);
    }
}

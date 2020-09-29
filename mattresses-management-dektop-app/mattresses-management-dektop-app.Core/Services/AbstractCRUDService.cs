using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services
{
    public class AbstractCRUDService<E, K> : ICRUDService<E, K>
    {
        private readonly IRepository<E, K> CrudRepository;
        public AbstractCRUDService(IRepository<E, K> crudRepository) {
            this.CrudRepository = crudRepository;
        }

        public T Find<T>(K key) where T : E, new()
        {
            return this.CrudRepository.Find<T>(key);
        }

        public int Insert(E item)
        {
            return this.CrudRepository.Insert(item);
        }
    }
}

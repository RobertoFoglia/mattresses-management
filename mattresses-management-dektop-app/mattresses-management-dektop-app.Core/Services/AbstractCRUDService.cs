using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services
{
    public abstract class AbstractCRUDService<E, K> : ICRUDService<E, K> where E : new()
    {
        private readonly IRepository<E, K> CrudRepository;
        public AbstractCRUDService(IRepository<E, K> crudRepository) {
            this.CrudRepository = crudRepository;
        }

        public E Find(K key)
        {
            return this.CrudRepository.Find(key);
        }

        public List<E> FindAll()
        {
            return this.CrudRepository.FindAll();
        }

        public int Insert(E item)
        {
            return this.CrudRepository.Insert(item);
        }

        public int Update(E item)
        {
            return this.CrudRepository.Update(item);
        }
    }
}

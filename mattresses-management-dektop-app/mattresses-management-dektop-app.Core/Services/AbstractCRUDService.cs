using mattresses_management_dektop_app.Core.Exceptions;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace mattresses_management_dektop_app.Core.Services
{
    public abstract class AbstractCRUDService<E, K> : ICRUDService<E, K> where E : new()
    {
        private readonly IRepository<E, K> CrudRepository;

        public AbstractCRUDService(IRepository<E, K> crudRepository)
        {
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

        public int Delete(K key)
        {
            var result = this.CrudRepository.Delete(key);
            if (result == 0)
                throw new UserOperationException("Cancellazione non effettuata.");
            return result;
        }

        public int Delete(E entity)
        {
            var result = this.CrudRepository.Delete(entity);
            if (result == 0)
                throw new UserOperationException("Cancellazione non effettuata.");
            return result;
        }

        public List<E> Where(Expression<Func<E, bool>> predExpr)
        {
            return this.CrudRepository.Where(predExpr);
        }

        public int InsertAll(List<E> items)
        {
            return this.CrudRepository.InsertAll(items);
        }
    }
}
using Phoenix.Aspects.Logging;
using Phoenix.LayerBases.DataAccess;
using Phoenix.LayerBases.DataAccess.EntityFramework;
using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Phoenix.LayerBases.Business
{
    public abstract class ServiceBase<T, TId> : IService<T>
        where T : class, IEntity<TId>, new()
    {
        public IRepository<T> _repository;
        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            if (_repository == null)
                throw new NullReferenceException("Repository is null in ServiceBase");

            _repository.Add(entity);
        }

        [LogAspect]
        public T Get(Expression<Func<T, bool>> filter)
        {
            if (_repository == null)
                throw new NullReferenceException("Repository is null in ServiceBase");

            return _repository.Get(filter);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter)
        {
            if (_repository == null)
                throw new NullReferenceException("Repository is null in ServiceBase");

            return _repository.GetList(filter);
        }

        public void Update(T entity)
        {
            if (_repository == null)
                throw new NullReferenceException("Repository is null in ServiceBase");    

            _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            if (_repository == null)
                throw new NullReferenceException("Repository is null in ServiceBase");

            _repository.Delete(entity);
        }
    }
}

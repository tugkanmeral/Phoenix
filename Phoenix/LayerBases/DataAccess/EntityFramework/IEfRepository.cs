using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Phoenix.LayerBases.DataAccess.EntityFramework
{
    public interface IEfRepository<T, TId> : IRepository<T>
        where T : class, IEntity<TId>, new()
    {
        new T Get(Expression<Func<T, bool>> filter = null);
        new IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);
        new void Add(T entity);
        new void Update(T entity);
        new void Delete(T entity);
    }
}
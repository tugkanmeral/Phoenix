using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Phoenix.LayerBases.Business
{
    public interface IService<T>
    {
        void Add(T entity);
        T Get(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);
        void Update(T entity);
        void Delete(T entity);
    }
}

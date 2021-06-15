﻿using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Phoenix.LayerBases.DataAccess.EntityFramework
{
    public interface IEfRepository<T, TId> : IRepository<T>
        where T : class, IEntity<TId>, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
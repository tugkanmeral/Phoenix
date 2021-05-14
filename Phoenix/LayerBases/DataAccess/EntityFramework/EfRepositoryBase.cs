using Microsoft.EntityFrameworkCore;
using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Phoenix.LayerBases.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TId> : IEfRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>, new()
    {
        private DbContext _context;
        public EfRepositoryBase(DbContextBase context)
        {
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public virtual void Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

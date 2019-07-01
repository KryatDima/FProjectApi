using FProject.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class, IEntity
    {
        protected DbContext DbContext;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await DbContext.AddAsync(entity);
            return entity;
            
        }

        public async Task<IEnumerable<TEntity>> Add(IReadOnlyCollection<TEntity> entities)
        {
            await DbContext.AddAsync(entities);
            return entities;
            
        }

        public void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbContext.Attach(entity);
            }

            DbContext.Remove(entity);
            
        }

        public void Delete(IReadOnlyCollection<TEntity> entities)
        {
            if (DbContext.Entry(entities).State == EntityState.Detached)
            {
                DbContext.Attach(entities);
            }

            DbContext.Remove(entities);
            
        }

        public async Task<TEntity> Get(long id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
            
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return DbContext.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }
    }
}

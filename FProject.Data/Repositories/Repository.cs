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
            var addedEntity = await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<IEnumerable<TEntity>> Add(IReadOnlyCollection<TEntity> entities)
        {
            var addedEntities = await DbContext.AddAsync(entities);
            await DbContext.SaveChangesAsync();
            return addedEntities.Entity;
            
        }

        public bool Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbContext.Attach(entity);
            }

            var deleted = DbContext.Remove(entity);
            DbContext.SaveChanges();
            return deleted.State == EntityState.Deleted;
        }

        public bool Delete(IReadOnlyCollection<TEntity> entities)
        {
            if (DbContext.Entry(entities).State == EntityState.Detached)
            {
                DbContext.Attach(entities);
            }

            var deleted = DbContext.Remove(entities);
            return deleted.State == EntityState.Deleted;
        }

        public async Task<TEntity> Get(long id) => await DbContext.Set<TEntity>().FindAsync(id);

        public IQueryable<TEntity> GetQueryable() => DbContext.Set<TEntity>();

        public async Task<TEntity> Update(TEntity entity)
        {
            var updatedEntity = DbContext.Update(entity);
            await DbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace FProject.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity:IEntity
    {
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> Add(IReadOnlyCollection<TEntity> entities);

        Task<TEntity> Get(long Id);
        IQueryable<TEntity> GetQueryable();

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
        void Delete(IReadOnlyCollection<TEntity> entities);
    }
}

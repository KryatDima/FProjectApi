using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task<int> SaveChangesAsync();
        IBasketItemRepository BasketItemRepository { get; }
        IUserRepository UserRepository { get; }
    }
}

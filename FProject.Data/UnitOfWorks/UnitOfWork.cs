using FProject.Data.Context;
using FProject.Data.Interfaces;
using FProject.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Dictionary<Type, object> repositories;
        private IDbContextTransaction transaction;
        private readonly object createdRepositoryLock;
        private bool transactionClosed;
        private readonly FProjectDbContext dbContext;
        private bool disposed = false;

        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(dbContext);
                return userRepository;
            }
        }

        public UnitOfWork(FProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
            repositories = new Dictionary<Type, object>();
            createdRepositoryLock = new object();
            transactionClosed = true;
            transaction = null;
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            if (!repositories.ContainsKey(typeof(TEntity)))
            {
                lock (createdRepositoryLock)
                {
                    repositories.Add(typeof(TEntity), new Repository<TEntity>(dbContext));
                }
            }

            return repositories[typeof(TEntity)] as IRepository<TEntity>;
        }

        public void BeginTransaction()
        {
            if (transactionClosed || transaction == null)
            {
                transaction = dbContext.Database.BeginTransaction();
                transactionClosed = false;
            }
        }

        public void CommitTransaction()
        {
            if (!transactionClosed)
            {
                transaction?.Commit();
                transactionClosed = true;
            }
        }

        public void RollbackTransaction()
        {
            if (!transactionClosed)
            {
                transaction?.Rollback();
                transactionClosed = true;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
                dbContext.Dispose();
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
    }
}

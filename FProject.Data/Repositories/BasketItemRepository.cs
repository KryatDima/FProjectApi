using FProject.Data.Entities;
using FProject.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Repositories
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private DbContext dbContext;

        public BasketItemRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(BasketItems item)
        {
            dbContext.Set<BasketItems>().Remove(item);
        }

        public void AddItem(BasketItems item)
        {
            dbContext.Set<BasketItems>().Add(item);
        }

        public void Delete(IReadOnlyCollection<BasketItems> entities)
        {
            if (dbContext.Entry(entities).State == EntityState.Detached)
            {
                dbContext.Attach(entities);
            }

            dbContext.Remove(entities);

        }

    }
}

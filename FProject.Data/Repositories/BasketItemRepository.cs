using FProject.Data.Entities;
using FProject.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.Repositories
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private DbContext dbContext;

        public BasketItemRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Delete(BasketItems item)
        {
            var a = dbContext.Set<BasketItems>().Remove(item).State;
            return  a==EntityState.Deleted;
        }

        public void AddItem(BasketItems item)
        {
            dbContext.Set<BasketItems>().Add(item);
        }

        public bool Delete(IReadOnlyCollection<BasketItems> entities)
        {
            if (dbContext.Entry(entities).State == EntityState.Detached)
            {
                dbContext.Attach(entities);
            }

            var result=dbContext.Remove(entities).State;
            return result==EntityState.Deleted;
        }

        public async Task<BasketItems> Update(BasketItems item)
        {
            var updatedEntity = dbContext.Update(item);
            await dbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public List<BasketItems> Get(long basketId)
        {
            return dbContext.Set<BasketItems>().Where(bi => bi.BasketId == basketId)
                .ToList();
        }
    }
}

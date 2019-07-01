using FProject.Data.Entities;
using FProject.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Basket> GetBasketByUserId(long userId)
        {
            return await DbContext.Set<Basket>().FirstOrDefaultAsync(x=>x.UserId==userId);
        }
    }
}

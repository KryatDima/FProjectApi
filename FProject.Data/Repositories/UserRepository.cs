using FProject.Data.Entities;
using FProject.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace FProject.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await DbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetForUserPageAsync(long id)
        {
            return await DbContext.Set<User>().Where(x => x.Id == id)
                .Include(x => x.Orders)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetWithOrdersAsync(long id)
        {
            return await DbContext.Set<User>().Where(x => x.Id == id)
                .Include(x => x.Orders)
                .FirstAsync();
        }
    }
}

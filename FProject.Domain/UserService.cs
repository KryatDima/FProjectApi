using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> Get(long id)
        {
            return await unitOfWork
        }

        public Task<User> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> Create()
        {
            throw new NotImplementedException();
        }
    }
}

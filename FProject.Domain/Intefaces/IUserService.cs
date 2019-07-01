using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IUserService
    {
        Task<User> Get(long id);
        Task<User> Authenticate(string username, string password);
        Task<User> Create();
        //Task<User> 
    }
}

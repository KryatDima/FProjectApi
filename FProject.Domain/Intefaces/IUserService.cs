using FProject.Data.Entities;
using FProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IUserService
    {
        Task<User> Get(long id);
        Task<User> AuthenticateAsync(string username, string password);
        Task<User> CreateAsync(RegisterModel model);
        //Task<User> 
    }
}

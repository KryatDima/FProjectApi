using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IAutentificationService
    {
        Task<UserDTO> Authenticate(string email, string password);
    }
}

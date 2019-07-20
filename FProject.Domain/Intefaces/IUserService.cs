using FProject.Contracts;
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
        //Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> Get(long id);
        Task<UserDTO> CreateAsync(RegisterModelDTO model);
        Task<UserDTO> Update(UserDTO userP);
        Task<bool> Delete(long id);

    }
}

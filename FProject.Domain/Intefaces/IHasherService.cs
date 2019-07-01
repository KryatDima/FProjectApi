using FProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IHasherService
    {
        Task<PasswordHash> CreatePasswordHash(string password);
        Task<bool> VerifyPasswordHash(string password, PasswordHash hash);
        string ByteToString(byte[] a);
    }
}

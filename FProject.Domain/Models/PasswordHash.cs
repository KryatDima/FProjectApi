using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain.Models
{
    public class PasswordHash
    {
        public PasswordHash()
        { }
        public PasswordHash(byte[] hash, byte[] salt)
        {
            Hash = hash ?? throw new ArgumentNullException(nameof(hash));
            Salt = salt ?? throw new ArgumentNullException(nameof(salt));
        }

        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}

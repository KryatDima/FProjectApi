using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class UserDTO : UpdateUserDTO
    {
        public string Role { get; set; }
        public string Token { get; set; }
    }
}

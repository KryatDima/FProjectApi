using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class UpdateUserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }
    }
}

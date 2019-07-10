using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DeliveryAddress { get; set; }
    }
}

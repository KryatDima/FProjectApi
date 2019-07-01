using FProject.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace FProject.Data.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }
        public virtual List<Order> Orders { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

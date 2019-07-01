using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain.Models
{
    class RegisterModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public string ImageUrl { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string About { get; set; }
        public long? GenderId { get; set; }
        public long? CountryId { get; set; }
    }
}

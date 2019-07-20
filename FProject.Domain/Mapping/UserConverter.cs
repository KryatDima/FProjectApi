using System;
using FProject.Contracts;
using FProject.Data.Entities;

namespace FProject.Domain.Mapping
{
    public static class UserConverter
    {
        public static UserDTO Convert(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return new UserDTO
            {
                Id = user.Id,
                DateOfBirth = user.DateOfBirth,
                DeliveryAddress = user.DeliveryAddress,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Token = user.Token
            };
        }

        public static User Convert(UserDTO user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return new User
            {
                Id = user.Id,
                DateOfBirth = user.DateOfBirth,
                DeliveryAddress = user.DeliveryAddress,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Token = user.Token
            };
        }
    }
}

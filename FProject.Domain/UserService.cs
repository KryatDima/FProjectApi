using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using FProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHasherService Hasher;

        public UserService(IUnitOfWork unitOfWork,IHasherService hasher)
        {
            this.unitOfWork = unitOfWork;
            Hasher = hasher;
        }

        public async Task<User> Get(long id)
        {
            return await unitOfWork.UserRepository.Get(id);
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = await unitOfWork.UserRepository.GetByEmailAsync(email);

            if (user == null)
                return null;

            if (await Hasher.VerifyPasswordHash(password, new PasswordHash(user.PasswordHash, user.PasswordSalt)))
                return user;

            return null;
        }

        public async Task<User> CreateAsync(RegisterModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Password))
                throw new Exception("Password is required");

            if (await unitOfWork.UserRepository.GetByEmailAsync(model.Email) != null)
                throw new Exception("This email is already registered");

            
            var User = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                DeliveryAddress = model.DeliveryAddress,
                PhoneNumber = model.PhoneNumber,
            };

            PasswordHash ph = await Hasher.CreatePasswordHash(model.Password);

            User.PasswordHash = ph.Hash;
            User.PasswordSalt = ph.Salt;

            await unitOfWork.UserRepository.Add(User);
            await unitOfWork.SaveChangesAsync();

            return User;
        }
    }
}

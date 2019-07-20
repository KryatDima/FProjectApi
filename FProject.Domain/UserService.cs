using FProject.Contracts;
using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using FProject.Domain.Mapping;
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
        private readonly IHasherService hasher;
        private readonly IBasketService basketService;

        public UserService(IUnitOfWork unitOfWork,IHasherService hasher,IBasketService basketService)
        {
            this.unitOfWork = unitOfWork;
            this.hasher = hasher;
            this.basketService = basketService;
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await unitOfWork.Repository<User>().Get(id);

            if (user == null) return null;

            return UserConverter.Convert(user);
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = await unitOfWork.UserRepository.GetByEmailAsync(email);

            if (user == null) return null;

            return UserConverter.Convert(user);
        }

        private async Task<User> GetUserEntity(long id) => await unitOfWork.Repository<User>().Get(id);

        public async Task<UserDTO> CreateAsync(RegisterModelDTO model)
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

            PasswordHash ph = await hasher.CreatePasswordHash(model.Password);

            User.PasswordHash = ph.Hash;
            User.PasswordSalt = ph.Salt;

            User.Role = Role.User;
            await unitOfWork.UserRepository.Add(User);
            await basketService.Create(User.Id);
            await unitOfWork.SaveChangesAsync();
            return UserConverter.Convert(User);
        }

        public async Task<UserDTO> Update(UserDTO userP) // UpdateUserDTO
        {
            var userParam = UserConverter.Convert(userP);

            var user = await unitOfWork.Repository<User>().Get(userParam.Id);


            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (userParam.Email != user.Email)
            {
                if (await unitOfWork.UserRepository.GetByEmailAsync(userParam.Email) != null)
                    throw new Exception("email " + userParam.Email + " is already taken");
                else
                    user.Email = userParam.Email;
            }

            //if (!string.IsNullOrWhiteSpace(password))
            //{
            //    PasswordHash ph = await hasher.CreatePasswordHash(password);

            //    userParam.PasswordHash = ph.Hash;
            //    userParam.PasswordSalt = ph.Salt;
            //}

            if (string.IsNullOrWhiteSpace(userParam.PhoneNumber))
                throw new Exception("can't be empty or null");
            else
                user.PhoneNumber = userParam.PhoneNumber;

            if (string.IsNullOrWhiteSpace(userParam.DeliveryAddress))
                throw new Exception("can't be empty or null");
            else
                user.DeliveryAddress = userParam.DeliveryAddress;

            if (string.IsNullOrWhiteSpace(userParam.FirstName))
                throw new Exception("can't be empty or null");
            else
                user.FirstName = userParam.FirstName;

            if (string.IsNullOrWhiteSpace(userParam.LastName))
                throw new Exception("can't be empty or null");
            else
                user.LastName = userParam.LastName;

            user =  await unitOfWork.Repository<User>().Update(user);
            return UserConverter.Convert(user);
        }

        public async Task<bool> Delete(long id)
        {
                var entity = await GetUserEntity(id);
                if (entity == null) return false;
                var result =unitOfWork.Repository<User>().Delete(entity);
                return !result;
        }
    }
}

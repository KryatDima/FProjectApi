using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using FProject.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using FProject.Contracts;
using FProject.Domain.Mapping;

namespace FProject.Domain
{
    public class AutentificationService : IAutentificationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHasherService hasher;
        private readonly AppSettings _appSettings;

        public AutentificationService(IUnitOfWork unitOfWork, IHasherService hasher, IOptions<AppSettings> appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.hasher = hasher;
            _appSettings = appSettings.Value;
        }

        public async Task<UserDTO> Authenticate(string email, string password)
        {
            var user = unitOfWork.Repository<User>().GetQueryable().SingleOrDefault(x => x.Email == email);

            // return null if user not found
            if (user == null)
                return null;

            var passCheck = await hasher.VerifyPasswordHash(password, new PasswordHash(user.PasswordHash, user.PasswordSalt));

            if (!passCheck)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);


            return UserConverter.Convert(user);
        }




        //public async Task<User> AuthenticateAsync(string email, string password) // TODO move to AuthService
        //{
        //    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        //        return null;

        //    var user = await unitOfWork.UserRepository.GetByEmailAsync(email);

        //    if (user == null)
        //        return null;

        //    if (await hasher.VerifyPasswordHash(password, new PasswordHash(user.PasswordHash, user.PasswordSalt)))
        //        return user;

        //    return null;
        //}
    }
}

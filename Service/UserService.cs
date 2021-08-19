using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HrAuth.Configurations;
using HrAuth.Dto;
using HrAuth.Models;
using HrAuth.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HrAuth.Service{


    public class UserService : IUserService
    {
        private readonly UserRepository userRepository;

        private readonly JwtConfiguration jwtConfiguration;

        public UserService(UserRepository UserRepository,IOptionsMonitor<JwtConfiguration> optionsMonitor)
        {
            this.userRepository = UserRepository;
            this.jwtConfiguration = optionsMonitor.CurrentValue;
        }
        
        public async Task<ResponseDto> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await userRepository.FindByEmail(loginDto.Email);

            if(user != null){
                if(loginDto.Password == user.Password){
                    var token = generateToken(user);
                    return new ResponseDto
                    {
                        success = true,
                        token = token,
                        errors = null
                    };
                }else{
                    return new ResponseDto
                    {
                        success = false,
                        token = null,
                        errors = new List<String>{"Invalid username or password"}
                    };;
                }
            }

            return new ResponseDto
            {
                success = false,
                token = null,
                errors = new List<String>{"Invalid username or password"}
            };;
        }

        public async Task<ResponseDto> CreateUserAsync(CreateUserDto createUser)
        {

            var existingUser = await userRepository.FindByEmail(createUser.Email);

            if(existingUser != null)
            {
                return new ResponseDto
                {
                    success = false,
                    token = null,
                    errors = new List<string> { "User exists" }
                };
            }

            var user = new User{
                UserId = Guid.NewGuid(),
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email,
                Password = createUser.Password, //TODO: Encrypt user password
                CompanyId = "0",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            var saved = await userRepository.SaveAsync(user);

            if (saved == 1)
            {
                var token = generateToken(user);
                return new ResponseDto
                {
                    success = true,
                    token = token,
                    errors = null
                };
            }

            return new ResponseDto
            {
                success = false,
                token = null,
                errors = new List<String>{"Error while creating user."}
            };
           
        }

        private string generateToken(User user)
        {
            var secret = Encoding.ASCII.GetBytes(jwtConfiguration.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id",user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString().Replace("-",""))
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha512Signature)
            };

            var jwtTokenHander = new JwtSecurityTokenHandler();
            var token = jwtTokenHander.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHander.WriteToken(token);

            return jwtToken;
        }
    }

}
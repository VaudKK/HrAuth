using System;
using System.Threading.Tasks;
using HrAuth.Dto;
using HrAuth.Models;
using HrAuth.Repository;

namespace HrAuth.Service{

    public class UserService : IUserService
    {
        private readonly UserRepository UserRepository;

        public UserService(UserRepository UserRepository){
            this.UserRepository = UserRepository;
        }
        
        public Task<bool> AuthenticateAsync(UserAuthDto userAuthDto)
        {
            throw new NotSupportedException();
        }

        public async Task CreateUserAsync(CreateUserDto createUser)
        {
            var user = new User{
                UserId = new Guid(),
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email,
                Password = createUser.Password,
                PrimaryContact = createUser.PrimaryContact,
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = DateTimeOffset.UtcNow
            };

            await UserRepository.SaveAsync(user);
        }
    }

}
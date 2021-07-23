using System.Threading.Tasks;
using HrAuth.Dto;

namespace HrAuth.Service{

    public interface IUserService{

        Task CreateUserAsync(CreateUserDto createUser);

        Task<bool> AuthenticateAsync(UserAuthDto userAuthDto);

    }


}
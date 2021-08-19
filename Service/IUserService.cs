using System.Threading.Tasks;
using HrAuth.Dto;

namespace HrAuth.Service{

    public interface IUserService{

        Task<ResponseDto> CreateUserAsync(CreateUserDto createUser);

        Task<ResponseDto> AuthenticateAsync(LoginDto loginDto);

    }


}
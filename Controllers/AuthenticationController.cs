using System.Threading.Tasks;
using HrAuth.Dto;
using HrAuth.Service;
using Microsoft.AspNetCore.Mvc;

namespace HrAuth.Controllers{

    [ApiController]
    [Route("uaa")]
    public class AuthenticationController: Controller{

        private readonly IUserService userService;

        public AuthenticationController(IUserService userService){
            this.userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ResponseDto> CreateUserAsync(CreateUserDto createUserDto){
            return await userService.CreateUserAsync(createUserDto);
        }
        
    }

}
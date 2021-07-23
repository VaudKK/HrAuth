using System.Threading.Tasks;
using HrAuth.Dto;
using HrAuth.Service;
using Microsoft.AspNetCore.Mvc;

namespace HrAuth.Controllers{

    [ApiController]
    [Route("auth")]
    public class AuthenticationController: Controller{

        private readonly IUserService userService;

        public AuthenticationController(IUserService userService){
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(CreateUserDto createUserDto){           
            await userService.CreateUserAsync(createUserDto);
            return NoContent();
        }
        
    }

}
using ChatApp.BLL.Interfaces;
using ChatApp.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("avatar")]
        public async Task<ActionResult<UserAvatarDto>> UpdateAvatarAsync([FromForm] IFormFile newAvatar)
        {
            return Ok(await _userService.UpdateUserAvatarAsync(newAvatar));
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUserAsync(UserEditDto user)
        {
            return Ok(await _userService.UpdateUserAsync(user));
        }
    }
}

using ChatApp.BLL.Interfaces;
using ChatApp.Common.DTO.Mail;
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

        [AllowAnonymous]
        [HttpPost("send-reset-email")]
        public async Task<ActionResult> SendEmailAsync(ResetEmailDto resetEmail)
        {
            await _userService.SendResetEmailAsync(resetEmail.Email);

            return Ok();
        }

        [HttpPost("reset")]
        [AllowAnonymous]
        public async Task<ActionResult> ResetPasswordAsync(ResetPasswordDto newInfo)
        {
            await _userService.ResetPasswordAsync(newInfo);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUserAsync(UserEditDto user)
        {
            return Ok(await _userService.UpdateUserAsync(user));
        }
    }
}

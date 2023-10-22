using ChatApp.BLL.Interfaces.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthUserDto>> RegisterAsync([FromBody] UserRegisterDto userDto)
        {
            return Created("register", await _authService.RegisterAsync(userDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUserDto>> LoginAsync([FromBody] UserLoginDto userDto)
        {
            return Ok(await _authService.LoginAsync(userDto));
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AccessTokenDto>> RefreshAsync([FromBody] AccessTokenDto tokenDto)
        {
            return Ok(await _authService.RefreshTokenAsync(tokenDto));
        }

        [HttpDelete("removetoken")]
        [Authorize]
        public async Task<ActionResult> RemoveRefreshTokenAsync(string refreshToken)
        {
            await _authService.RemoveRefreshTokenAsync(refreshToken);
            return NoContent();
        }
    }
}

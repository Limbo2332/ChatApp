using ChatApp.BLL.Interfaces.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace ChatApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserRegisterDto userDto)
        {
            return Created("register", await _authService.Register(userDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUserDto>> Login(UserLoginDto userDto)
        {
            return Ok(await _authService.Login(userDto));
        }

        [HttpPost("refresh")]
        [Authorize]
        public async Task<ActionResult<AccessTokenDto>> Refresh(AccessTokenDto tokenDto)
        {
            return Ok(await _authService.RefreshToken(tokenDto));
        }

        [HttpPost("removetoken")]
        [Authorize]
        public async Task<ActionResult> RemoveRefreshToken(string refreshToken)
        {
            await _authService.RemoveRefreshToken(refreshToken);
            return NoContent();
        }
    }
}

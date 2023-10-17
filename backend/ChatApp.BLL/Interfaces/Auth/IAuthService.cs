using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;

namespace ChatApp.BLL.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthUserDto> Login(UserLoginDto userDto);

        Task<UserDto> Register(UserRegisterDto userDto);

        Task<AccessTokenDto> RefreshToken(AccessTokenDto tokenDto);
    }
}

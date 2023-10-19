using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;

namespace ChatApp.BLL.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthUserDto> LoginAsync(UserLoginDto userDto);

        Task<UserDto> RegisterAsync(UserRegisterDto userDto);

        Task<AccessTokenDto> RefreshTokenAsync(AccessTokenDto tokenDto);

        Task RemoveRefreshTokenAsync(string token);
    }
}

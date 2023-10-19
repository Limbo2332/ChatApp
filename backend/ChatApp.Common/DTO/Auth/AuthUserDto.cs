using ChatApp.Common.DTO.User;

namespace ChatApp.Common.DTO.Auth
{
    public class AuthUserDto
    {
        public UserDto User { get; set; } = null!;

        public AccessTokenDto Token { get; set; } = null!;
    }
}

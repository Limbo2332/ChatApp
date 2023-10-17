using AutoMapper;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Security;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.BLL.Services.Auth
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IJwtService _jwtService;

        public AuthService(IJwtService jwtService, ChatAppContext context, IMapper mapper) 
            : base(context, mapper)
        {
            _jwtService = jwtService;
        }

        public async Task<AuthUserDto> Login(UserLoginDto userDto)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(user => user.Email == userDto.EmailOrUserName 
                    || user.UserName == userDto.EmailOrUserName);

            if (userEntity == null)
            {
                throw new Exception(nameof(User));
            }

            if(!SecurityHelper.ValidatePassword(userDto.Password, userEntity.Password, userEntity.Salt))
            {
                throw new Exception(nameof(User));
            }

            var token = await GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email);
            var user = _mapper.Map<UserDto>(userEntity);

            return new AuthUserDto
            {
                Token = token,
                User = user
            };
        }

        public async Task<UserDto> Register(UserRegisterDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var salt = SecurityHelper.GetRandomBytes();

            user.Salt = Convert.ToBase64String(salt);
            user.Password = SecurityHelper.HashPassword(userDto.Password, salt);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        private async Task<AccessTokenDto> GenerateAccessToken(int userId, string userName, string email)
        {
            var refreshTokenEntity = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.UserId == userId);

            var refreshToken = _jwtService.GenerateRefreshToken();

            if (refreshTokenEntity is null)
            {
                await _context.RefreshTokens.AddAsync(new RefreshToken
                {
                    Token = refreshToken,
                    UserId = userId,
                });

                await _context.SaveChangesAsync();
            }

            var accessToken = _jwtService.GenerateAccessToken(userId, userName, email);

            return new AccessTokenDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenEntity?.Token ?? refreshToken,
            };
        }
    }
}

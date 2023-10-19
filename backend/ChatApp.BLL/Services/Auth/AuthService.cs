using AutoMapper;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.DAL.Entities;
using ChatApp.Common.Security;
using ChatApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ChatApp.Common.Logic.Abstract;

namespace ChatApp.BLL.Services.Auth
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _config;
        private readonly IUserIdGetter _userIdGetter;

        public AuthService(IJwtService jwtService, ChatAppContext context, IMapper mapper, IConfiguration config, IUserIdGetter userIdGetter)
            : base(context, mapper)
        {
            _jwtService = jwtService;
            _config = config;
            _userIdGetter = userIdGetter;
        }

        public async Task<AuthUserDto> LoginAsync(UserLoginDto userDto)
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

        public async Task<AuthUserDto> RegisterAsync(UserRegisterDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var salt = SecurityHelper.GetRandomBytes();

            userEntity.Salt = Convert.ToBase64String(salt);
            userEntity.Password = SecurityHelper.HashPassword(userDto.Password, salt);

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            var token = await GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email);
            var user = _mapper.Map<UserDto>(userEntity);

            return new AuthUserDto
            {
                Token = token,
                User = user
            };
        }

        public async Task<AccessTokenDto> RefreshTokenAsync(AccessTokenDto tokenDto)
        {
            var userId = _jwtService.GetUserIdFromToken(tokenDto.AccessToken, _config["JWT:SigningKey"]!);
            var userEntity = await _context.Users.FindAsync(userId)
                ?? throw new Exception(nameof(User));

            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == tokenDto.RefreshToken && rt.UserId == userId)
                ?? throw new Exception("Refresh");

            if (!refreshToken.IsActive)
            {
                throw new Exception("Refresh token expired");
            }

            var jwtToken = _jwtService.GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email);
            var rToken = _jwtService.GenerateRefreshToken();

            _context.RefreshTokens.Remove(refreshToken);
            _context.RefreshTokens.Add(new DAL.Entities.RefreshToken
            {
                Token = rToken,
                UserId = userEntity.Id
            });

            await _context.SaveChangesAsync();

            return new AccessTokenDto()
            {
                AccessToken = jwtToken,
                RefreshToken = rToken
            };
        }

        public async Task RemoveRefreshTokenAsync(string token)
        {
            var currentUserId = _userIdGetter.CurrentUserId;
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == token && rt.UserId == currentUserId)
                ?? throw new Exception("refresh");

            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();
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

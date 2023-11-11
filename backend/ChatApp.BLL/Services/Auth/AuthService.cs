using AutoMapper;
using ChatApp.BLL.Hubs;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Logic.Abstract;
using ChatApp.Common.Security;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChatApp.BLL.Services.Auth
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthService(
            IMapper mapper,
            IUserIdGetter userIdGetter,
            IJwtService jwtService,
            IConfiguration config,
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository)
            : base(mapper, userIdGetter)
        {
            _jwtService = jwtService;
            _config = config;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AuthUserDto> LoginAsync(UserLoginDto userDto)
        {
            var userEntity = await _userRepository.GetByExpressionAsync(
                user => user.Email == userDto.EmailOrUserName
                    || user.UserName == userDto.EmailOrUserName)
                ?? throw new NotFoundException(nameof(User));

            if (!SecurityHelper.ValidatePassword(userDto.Password, userEntity.Password, userEntity.Salt))
            {
                throw new NotFoundException(nameof(User), userEntity.Id);
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

            await _userRepository.AddAsync(userEntity);

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
            var userId = _jwtService.GetUserIdFromToken(tokenDto.AccessToken, _config.GetSection("JWT:SigningKey").Value!);
            var userEntity = await _userRepository
                .GetByExpressionAsync(user => user.Id == userId)
                ?? throw new NotFoundException(nameof(User));

            var refreshToken = await _refreshTokenRepository
                .GetByExpressionAsync(rt => rt.Token == tokenDto.RefreshToken && rt.UserId == userId)
                ?? throw new InvalidTokenException(nameof(tokenDto.RefreshToken));

            if (!refreshToken.IsActive)
            {
                throw new ExpiredRefreshTokenException();
            }

            var jwtToken = _jwtService.GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email);
            var rToken = _jwtService.GenerateRefreshToken();

            await _refreshTokenRepository.DeleteAsync(refreshToken.Id);

            var newRefreshToken = new RefreshToken
            {
                Token = rToken,
                UserId = userEntity.Id
            };

            await _refreshTokenRepository.AddAsync(newRefreshToken);

            return new AccessTokenDto()
            {
                AccessToken = jwtToken,
                RefreshToken = rToken
            };
        }

        public async Task RemoveRefreshTokenAsync(string token)
        {
            var currentUserId = _userIdGetter.CurrentUserId;
            var refreshToken = await _refreshTokenRepository
                .GetByExpressionAsync(rt => rt.Token == token && rt.UserId == currentUserId)
                ?? throw new InvalidTokenException(nameof(token));

            await _refreshTokenRepository.DeleteAsync(refreshToken.Id);
        }

        private async Task<AccessTokenDto> GenerateAccessToken(int userId, string userName, string email)
        {
            var refreshTokenEntity = await _refreshTokenRepository
                .GetByExpressionAsync(rt => rt.UserId == userId);

            var refreshToken = _jwtService.GenerateRefreshToken();

            if (refreshTokenEntity is null)
            {
                var newRefreshToken = new RefreshToken
                {
                    Token = refreshToken,
                    UserId = userId,
                };

                await _refreshTokenRepository.AddAsync(newRefreshToken);
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

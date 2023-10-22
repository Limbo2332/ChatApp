﻿using ChatApp.BLL.Interfaces.Auth;
using ChatApp.Common.DTO.Auth;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.BLL.Services.Auth
{
    public class JwtService : IJwtService
    {
        private const int ACCESS_TOKEN_EXPIRES_IN_MINUTES = 120;
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateAccessToken(int userId, string userName, string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", userId.ToString())
            };

            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(ACCESS_TOKEN_EXPIRES_IN_MINUTES),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(SecurityHelper.GetRandomBytes());
        }

        public int GetUserIdFromToken(string accessToken, string signingKey)
        {
            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(accessToken,
                new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
                }, out var securityToken)
                ?? throw new NotFoundException(nameof(accessToken));

            return int.Parse(claimsPrincipal.Claims.First(c => c.Type == "id").Value);
        }
    }
}

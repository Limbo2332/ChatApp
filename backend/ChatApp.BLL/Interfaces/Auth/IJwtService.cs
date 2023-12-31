﻿namespace ChatApp.BLL.Interfaces.Auth
{
    public interface IJwtService
    {
        string GenerateAccessToken(int userId, string userName, string email);

        string GenerateRefreshToken();

        int GetUserIdFromToken(string accessToken, string signingKey);
    }
}

﻿using System.Security.Claims;

namespace EcommerceApp.Domain.Interfaces.Authentication
{
    public interface ITokenManagement
    {
        string GenerateRefreshToken();
        List<Claim> GetClaimsFromToken(string token);
        Task<bool> ValidateRefreshToken(string RefreshToken);
        Task<string> GetUserIdByRefreshToken(string RefreshToken);

        Task<int> AddRefreshToken(string userId, string refreshToken);
        Task<int> UpdateRefreshToken(string userId, string refreshToken);

        string GenerateToken(IEnumerable<Claim> claims);


    }
}

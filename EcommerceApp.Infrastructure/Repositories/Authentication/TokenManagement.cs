using EcommerceApp.Domain.Entities.Identity;
using EcommerceApp.Domain.Interfaces.Authentication;
using EcommerceApp.Infrastructure.Data;
using EcommerceApp.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace EcommerceApp.Infrastructure.Repositories.Authentication
{
    internal class TokenManagement(AppDbContext context ,IOptions<JwtSettings> jwtSettings) : ITokenManagement
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;
        public async Task<int> AddRefreshToken(string userId, string refreshToken)
        {
            context.RefreshTokens.Add(
                new RefreshToken()
                {
                    userId = userId,
                    Token = refreshToken,
                });
            return await context.SaveChangesAsync();
        }

        public Task<string> GenerateRefreshToken()
        {
            
        }

        public Task<string> GenerateToken(IEnumerable<Claim> claims)
        {
            
        }

        public List<Claim> GetClaimsFromToken(string RefreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdByRefreshToken(string RefreshToken)
        {
        }

        public Task<int> UpdateRefreshToken(string userId, string refreshToken)
        {
        }

        public Task<bool> ValidateRefreshToken(string RefreshToken)
        {
        }
    }
}

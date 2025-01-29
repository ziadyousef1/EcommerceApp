using System.Security.Claims;

namespace EcommerceApp.Domain.Interfaces.Authentication
{
    public interface ITokenManagement
    {
        Task<string> GenerateRefreshToken();
        List<Claim> GetClaimsFromToken(string RefreshToken);
        Task<bool> ValidateRefreshToken(string RefreshToken);
        Task<string> GetUserIdByRefreshToken(string RefreshToken);

        Task<int> AddRefreshToken(string userId, string refreshToken);
        Task<int> UpdateRefreshToken(string userId, string refreshToken);

        Task<string> GenerateToken(IEnumerable<Claim> claims);


    }
}

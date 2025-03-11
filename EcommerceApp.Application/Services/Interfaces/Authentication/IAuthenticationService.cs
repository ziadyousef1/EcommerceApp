using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Identity;

namespace EcommerceApp.Application.Services.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> CreateUser(CreateUser user);
        Task<LoginResponse> Login(LoginUser user);
        Task<LoginResponse> RefreshToken(string token);
    }
}

using AutoMapper;
using EcommerceApp.Application.DTOs;
using EcommerceApp.Application.DTOs.Identity;
using EcommerceApp.Application.Services.Interfaces.Authentication;
using EcommerceApp.Application.Services.Interfaces.Logging;
using EcommerceApp.Application.Validations;
using EcommerceApp.Domain.Entities.Identity;
using EcommerceApp.Domain.Interfaces.Authentication;
using FluentValidation;

namespace EcommerceApp.Application.Services.Implementations.Authentication
{
    public class AuthenticationService(
        IUserManagement userManagement,
        ITokenManagement tokenManagement,
        IRoleManagement roleManagement,
        IAppLogger<AuthenticationService> logger,
        IMapper mapper,
        IValidator<CreateUser> createUserValidator,
        IValidator<LoginUser> loginUserValidator,
        IValldationService validationService) : IAuthenticationService
    {

        public async Task<ServiceResponse> CreateUser(CreateUser user)
        {
            var  validationResult = await validationService.ValidateAsync(user, createUserValidator);
            if(!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var mappedUser = mapper.Map<AppUser>(user);
            mappedUser.UserName = user.Email;
            mappedUser.PasswordHash = user.Password;
            var result = await userManagement.CreateUser(mappedUser);
            if(!result)
            {
                return new ServiceResponse { Message = "User creation failed", IsSuccess = false };
            }

            var _user = await userManagement.GetUserByEmail(user.Email);
            var assignedResult = await roleManagement.AddUserToRole(_user, "User");
            
            if(!assignedResult)
            {
               int removeUserResult = await userManagement.RemoveUserByEmail(_user.Email);
                if(removeUserResult <= 0)
                {
                    logger.LogError( new Exception($"User with email {_user.Email} could not be removed"), "User Could not be assigned role" );
                    return new ServiceResponse{Message ="Error occured on creating account", IsSuccess = false};
                }
            }
            
            return new ServiceResponse{Message = "Account created successfully", IsSuccess = true};


        }

        public async Task<LoginResponse> Login(LoginUser user)
        {
            var validationResult = await validationService.ValidateAsync(user, loginUserValidator);
            if(!validationResult.IsSuccess)
            {
                return new LoginResponse( Message: validationResult.Message);
                
            }
            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.PasswordHash = user.Password;
            
            var loginResult = await userManagement.LoginUser(mappedModel);
            if(!loginResult)
            {
                return new LoginResponse(Message: "Invalid login attempt");
            }
            var _user = await userManagement.GetUserByEmail(user.Email);
            var claims = await userManagement.GetUserClaims(_user.Email);
            var refreshToken = tokenManagement.GenerateRefreshToken();
            var jwtToken = tokenManagement.GenerateToken(claims);
            int saveTokenResult = await tokenManagement.AddRefreshToken(_user.Email, refreshToken);
            var role = await roleManagement.GetUserRole(_user.Email);
            if(saveTokenResult <= 0)
            {
                logger.LogError(new Exception($"Refresh token could not be saved for user {_user.Email}"), "Refresh token could not be saved");
                return new LoginResponse(Message: "Error occured on login");
            }
            return new LoginResponse(IsSuccess: true, Token: jwtToken, RefreshToken: refreshToken,Role:role);
          
        }

        public async Task<LoginResponse> RefreshToken(string RefreshToken)
        {
          bool validateTokenResult = await tokenManagement.ValidateRefreshToken(RefreshToken);
            if(!validateTokenResult)
            {
                return new LoginResponse(Message: "Invalid refresh token");
            }
            var userId = await tokenManagement.GetUserIdByRefreshToken(RefreshToken); 
            var claims = await userManagement.GetUserClaims(userId);
            var newJwtToken = tokenManagement.GenerateToken(claims);
            var NewRefreshToken = tokenManagement.GenerateRefreshToken();
            int saveTokenResult = await tokenManagement.AddRefreshToken(userId, NewRefreshToken);
          
            return new LoginResponse(IsSuccess: true, Token: newJwtToken, RefreshToken: NewRefreshToken);
            
          
        }
    }
}

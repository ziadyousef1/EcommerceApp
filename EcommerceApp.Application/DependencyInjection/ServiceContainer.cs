using EcommerceApp.Application.Services.Implementations;
using EcommerceApp.Application.Services.Interfaces;
using EcommerceApp.Application.Validations;
using EcommerceApp.Application.Validations.Authentication;
using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using AuthenticationService = EcommerceApp.Application.Services.Implementations.Authentication.AuthenticationService;
using IAuthenticationService = EcommerceApp.Application.Services.Interfaces.Authentication.IAuthenticationService;

namespace EcommerceApp.Application.DependencyInjection
{
    public static class ServiceContainer
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(ServiceContainer));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddScoped<IValldationService, ValidationService>();
          
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }

    }
}

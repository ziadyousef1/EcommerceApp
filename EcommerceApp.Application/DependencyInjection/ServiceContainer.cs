using EcommerceApp.Application.Services.Implementations;
using EcommerceApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Application.DependencyInjection
{
    public static class ServiceContainer
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(ServiceContainer));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }

    }
}

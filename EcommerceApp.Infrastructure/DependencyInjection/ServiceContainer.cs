using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Infrastructure.Data;
using EcommerceApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Infrastructure.DependencyInjection
{
    public static class ServiceContainer 
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
             IConfiguration configration)
        { 
        
           services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGeneric<Product>,GenericRepository<Product>>();
            services.AddScoped<IGeneric<Category>,GenericRepository<Category>>();

            return services;
        }
    }
}

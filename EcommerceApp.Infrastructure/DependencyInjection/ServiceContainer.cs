using EcommerceApp.Application.Services.Interfaces.Logging;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Infrastructure.Data;
using EcommerceApp.Infrastructure.middleware;
using EcommerceApp.Infrastructure.Repositories;
using EcommerceApp.Infrastructure.Services;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EcommerceApp.Infrastructure.DependencyInjection
{
    public static class ServiceContainer 
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
             IConfiguration configration)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configration.GetConnectionString("DefaultConnection"))
            .UseExceptionProcessor());
            services.AddSingleton(Log.Logger);

            services.AddScoped<IGeneric<Product>,GenericRepository<Product>>();
            services.AddScoped<IGeneric<Category>,GenericRepository<Category>>();
            services.AddScoped(typeof(IAppLogger<>), typeof(SerilogLogger<>));

            return services;
        }
        public static IApplicationBuilder UseInfrastructureService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}

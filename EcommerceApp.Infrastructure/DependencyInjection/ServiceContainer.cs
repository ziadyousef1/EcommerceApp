﻿using EcommerceApp.Application.Services.Interfaces.Logging;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Entities.Identity;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Infrastructure.Data;
using EcommerceApp.Infrastructure.middleware;
using EcommerceApp.Infrastructure.Repositories;
using EcommerceApp.Infrastructure.Services;
using EcommerceApp.Infrastructure.Settings;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace EcommerceApp.Infrastructure.DependencyInjection
{
    public static class ServiceContainer 
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
             IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .UseExceptionProcessor());
            services.AddSingleton(Log.Logger);
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.JwtSetting));
            var jwtSettings = new JwtSettings();
            configuration.GetSection(JwtSettings.JwtSetting).Bind(jwtSettings);
            services.AddScoped<IGeneric<Product>,GenericRepository<Product>>();
            services.AddScoped<IGeneric<Category>,GenericRepository<Category>>();
            services.AddScoped(typeof(IAppLogger<>), typeof(SerilogLogger<>));
            services.AddDefaultIdentity<AppUser>( )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime =true,
                    RequireExpirationTime= true,
                    ValidIssuer= jwtSettings.Issuer,
                    ValidAudience= jwtSettings.Audience,
                    ClockSkew= TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    


                };

            }
            );

            return services;
        }
        public static IApplicationBuilder UseInfrastructureService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Identity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BankApp.Domain;
using BankApp.Infrastrucure.Services;
using BankApp.Application.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BankApp.Application.Features.AccountFeature.Commands.AddAccount;
namespace BankApp.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<BankIdentityDbContext>(options =>

                options.UseSqlServer(configuration.GetConnectionString("BankWebAPIconnString")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BankIdentityDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IAuthService, AuthServices>();
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddAccountCommand>());  // Replace with your appropriate class for MediatR

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });
            return services;
        }
        }
}

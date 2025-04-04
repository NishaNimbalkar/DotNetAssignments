using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Infrastrucure.Context;
using BankApp.Infrastrucure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Infrastrucure
{
    public static class InterfaceServiceRegistration
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BankWebAPIconnString"));


            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            return services;

        }
    }
}

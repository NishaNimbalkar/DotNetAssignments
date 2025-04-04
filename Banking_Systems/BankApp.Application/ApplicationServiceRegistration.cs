
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Application
{
    public static class ApplicationServiceRegistration
    {
        //create atatic method to registers Dependency

        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return service;
        }
    }
}

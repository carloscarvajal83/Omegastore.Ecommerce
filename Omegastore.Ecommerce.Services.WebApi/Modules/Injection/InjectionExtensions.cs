using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Omegastore.Ecommerce.Application.Interfaces;
using Omegastore.Ecommerce.Application.Main;
using Omegastore.Ecommerce.Domain.Core;
using Omegastore.Ecommerce.Domain.Interfaces;
using Omegastore.Ecommerce.Infrastructure.Data;
using Omegastore.Ecommerce.Infrastructure.Interfaces;
using Omegastore.Ecommerce.Infrastructure.Repository;
using Omegastore.Ecommerce.Shared.Common;
using Omegastore.Ecommerce.Shared.Logging;

namespace Omegastore.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdpater<>));
            return services;
        }
    }
}

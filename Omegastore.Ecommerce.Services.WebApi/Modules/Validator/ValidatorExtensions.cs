using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omegastore.Ecommerce.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Omegastore.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDtoValidator>();
            return services;
        }
    }
}

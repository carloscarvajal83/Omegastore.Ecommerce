using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Omegastore.Ecommerce.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration) {
            string myPolicy = "policyApiEcommerce";
            services.AddCors(
                options => options.AddPolicy
                (
                    myPolicy,
                    builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                )
            );
            services.AddMvc();
                //.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            return services;
        }
    }
}

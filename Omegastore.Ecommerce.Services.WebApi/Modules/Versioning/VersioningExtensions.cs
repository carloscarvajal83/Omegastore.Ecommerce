using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Omegastore.Ecommerce.Services.WebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(v => {
                v.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.ReportApiVersions = true;
                v.ApiVersionReader = new HeaderApiVersionReader("x-version");
            });
            services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
            });
            return services;
        }
    }
}

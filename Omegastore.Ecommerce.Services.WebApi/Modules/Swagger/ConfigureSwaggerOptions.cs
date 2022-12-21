using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Omegastore.Ecommerce.Services.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }   

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description) {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "OmegraStore Tech Services API Market",
                Description = "A simple ASP.NET Core Web Api",
                TermsOfService = new Uri("http://omegastore.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Charles Spark",
                    Email = "adminservices@omegastore.co",
                    Url = new Uri("http://omegastore.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "User under LICX",
                    Url = new Uri("http://omegastore.com/license")
                }
            };
            return info;
        }
    }
}

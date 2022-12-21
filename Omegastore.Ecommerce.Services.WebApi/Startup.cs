using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Omegastore.Ecommerce.Services.WebApi.Modules.Swagger;
using Omegastore.Ecommerce.Services.WebApi.Modules.Authentication;
using Omegastore.Ecommerce.Services.WebApi.Modules.Mapper;
using Omegastore.Ecommerce.Services.WebApi.Modules.Feature;
using Omegastore.Ecommerce.Services.WebApi.Modules.Injection;
using Omegastore.Ecommerce.Services.WebApi.Modules.Validator;
using Omegastore.Ecommerce.Services.WebApi.Modules.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;

namespace Omegastore.Ecommerce.Services.WebApi
{
    public class Startup
    {
        private readonly string myPolicy = "policyApiEcommerce";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMapper();
            services.AddFeature(this.Configuration);
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //.AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver(); });
            
            services.AddInjections(this.Configuration);
            services.AddAuthentication(this.Configuration);
            services.AddVersioning();
            services.AddSwagger();
            services.AddValidator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
            //app.UseMvc();
        }
    }
}

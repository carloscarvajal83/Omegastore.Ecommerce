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
            
            services.AddInjections(Configuration);
            services.AddAuthentication(this.Configuration);
            services.AddSwagger();
            services.AddValidator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Ecommerce V1");
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

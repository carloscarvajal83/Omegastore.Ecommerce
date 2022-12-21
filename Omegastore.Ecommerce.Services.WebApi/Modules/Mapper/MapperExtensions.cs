using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Omegastore.Ecommerce.Shared.Mapper;

namespace Omegastore.Ecommerce.Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services) {
            //services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}

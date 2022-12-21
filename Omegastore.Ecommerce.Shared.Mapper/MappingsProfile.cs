using System;
using AutoMapper;
using Omegastore.Ecommerce.Domain.Entity;
using Omegastore.Ecommerce.Application.Dto;

namespace Omegastore.Ecommerce.Shared.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            /*
            CreateMap<Customer, CustomerDto>().ReverseMap()
                .ForMember(target => target.Address, source => source.MapFrom(src => src.Address))
                .ForMember(target => target.City, source => source.MapFrom(src => src.City));
            */
        }
    }
}

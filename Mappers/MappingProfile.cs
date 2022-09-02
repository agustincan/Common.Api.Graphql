using AutoMapper;
using Common.Api.Graphql.Dtos;
using Common.Api.Graphql.Persistence.Models;

namespace Common.Api.Graphql.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}

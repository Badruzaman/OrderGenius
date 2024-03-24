using AutoMapper;
using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Dtos;

namespace OrderGenius.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CustomerDto, Customer>();
        }
    }
}

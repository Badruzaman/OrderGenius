using AutoMapper;
using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Entities.ProductAggregate;
using OrderGenius.Dtos;

namespace OrderGenius.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<ProductDto, Product>();
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
        }
    }
}

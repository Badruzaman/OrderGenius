using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderGenius.Core.Entities.Identity;
using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Interfaces;
using OrderGenius.Dtos;
using OrderGenius.Errors;

namespace OrderGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper mapper;
        public IOrderService OrderService { get; }
        public OrdersController(IOrderService orderService, IMapper mapper) 
        {
            OrderService = orderService;
            this.mapper = mapper;
        }
        [HttpPost(nameof(CreateOrder))]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            //var user = HttpContext.User.ReteriveEmailFromPrincipal();
            //var address = mapper.Map<AddressDto, Address>(orderDto.ShippingToAddress);
            //var order = await OrderService.CreateOrderAsync(
            //    );
            //if (order == null)
            //{
            //    return BadRequest(new APIResponce(400, "Something went Wrong"));
            //}
            //return Ok(order);

            return Ok(orderDto);
        }
    }
}

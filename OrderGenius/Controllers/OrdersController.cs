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
        public OrdersController(IOrderService orderService) 
        {
            OrderService = orderService;
            //this.mapper = mapper;
        }
        [HttpPost(nameof(CreateOrder))]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            //var user = HttpContext.User.ReteriveEmailFromPrincipal();
            //var address = mapper.Map<AddressDto, Address>(orderDto.ShippingToAddress);
            var order = new Order
            {
                OrderPlaced = orderDto.OrderPlaced,
                CustomerId = orderDto.CustomerId
            };
            foreach (var item in orderDto.Items)
            {
                var detail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    Qunatity = item.Qunatity,
                    Price = item.Price,
                };
                order.Items.Add(detail);
            }
            //var res = await OrderService.CreateOrderAsync(order);
            //if (res == null)
            //{
            //    return BadRequest(new APIResponce(400, "Something went Wrong"));
            //}
            return Ok(orderDto);
        }
    }
}

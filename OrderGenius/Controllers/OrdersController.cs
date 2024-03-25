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
            this.mapper = mapper;
        }
        [HttpPost(nameof(CreateOrder))]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            try
            {

            //var user = HttpContext.User.ReteriveEmailFromPrincipal();
            //var order1 = new Order
            //{
            //    OrderPlaced = orderDto.OrderPlaced,
            //    CustomerId = orderDto.CustomerId
            //};
            //foreach (var item in orderDto.Items)
            //{
            //    var detail = new OrderDetail
            //    {
            //        ProductId = item.ProductId,
            //        Qunatity = item.Qunatity,
            //        Price = item.Price,
            //    };
            //    order.Items.Add(detail);
            //}

            var order = mapper.Map<Order>(orderDto);
            var result = await OrderService.CreateOrderAsync(order);
            if (result == null)
            {
                return BadRequest(new APIResponce(400, "Something went Wrong"));
            }

            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(orderDto);
        }
    }
}

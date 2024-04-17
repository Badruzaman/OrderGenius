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
    public class ordersController : ControllerBase
    {
        private readonly IMapper _mapper;
        public IOrderService _orderService { get; }
        public ordersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpPost(nameof(createorder))]
        public async Task<ActionResult<Order>> createorder(OrderDto orderDto)
        {
            try
            {
                var order = _mapper.Map<Order>(orderDto);
                var result = await _orderService.CreateOrderAsync(order);
                if (result == null)
                {
                    return BadRequest(new APIResponce(400, "Something went Wrong"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponce(400, "Something went Wrong"));
            }
            return Ok(orderDto);
        }
    }
}

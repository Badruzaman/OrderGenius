using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderGenius.Application.Commands.Customers.Command;
using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Dtos;
using OrderGenius.Errors;
namespace OrderGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CustomersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost(nameof(CreateCustomer))]
        public async Task<ActionResult<Customer>> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                var result = await _mediator.Send(new AddCustomerCommand(customer)); 
                if (result == null)
                {
                    return BadRequest(new APIResponce(400, "Something went Wrong"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponce(400, "Something went Wrong " + ex.Message));
            }
            return Ok(customerDto);
        }
    }
}

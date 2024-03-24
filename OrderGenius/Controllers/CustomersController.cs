using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Interfaces;
using OrderGenius.Dtos;
using OrderGenius.Errors;

namespace OrderGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper mapper;
        public ICustomerService CustomerService { get; }
        public CustomersController(ICustomerService customerService, IMapper _mapper)
        {
            CustomerService = customerService;
            mapper = _mapper;
        }
        [HttpPost(nameof(CreateCustomer))]
        public async Task<ActionResult<Customer>> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                var customer = mapper.Map<Customer>(customerDto);
                var result = await CustomerService.CreateCustomerAsync(customer);
                if (result == null)
                {
                    return BadRequest(new APIResponce(400, "Something went Wrong"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponce(400, "Something went Wrong"));
            }
            return Ok(customerDto);
        }
    }
}

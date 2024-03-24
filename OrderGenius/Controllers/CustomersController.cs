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
        public CustomersController(ICustomerService customerService)
        {
            CustomerService = customerService;
            //this.mapper = mapper;
        }
        [HttpPost(nameof(CreateCustomer))]
        public async Task<ActionResult<Customer>> CreateCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Street = customerDto.Street,
                City = customerDto.City,
                State = customerDto.State,
                ZipCode = customerDto.ZipCode,
                Email = customerDto.Email,
                Phone = customerDto.Phone
            };
            var result = await CustomerService.CreateCustomerAsync(customer);
            if (result == null)
            {
                return BadRequest(new APIResponce(400, "Something went Wrong"));
            }
            return Ok(customerDto);
        }
    }
}

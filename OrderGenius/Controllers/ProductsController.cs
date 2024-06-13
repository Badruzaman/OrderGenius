using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderGenius.Application.Commands.Products.Command;
using OrderGenius.Core.Entities.ProductAggregate;
using OrderGenius.Dtos;
using OrderGenius.Errors;

namespace OrderGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public productController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost(nameof(createproduct))]
        public async Task<ActionResult<Product>> createproduct(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                var result = await _mediator.Send(new AddProductCommand(product)); 
                if (result == null)
                {
                    return BadRequest(new APIResponce(400, "Something went wrong"));
                }
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //   "Error storing data in the database");
                return BadRequest(new APIResponce(0, "Something went wrong"));
            }
            return Ok(productDto);
        }
    }
}

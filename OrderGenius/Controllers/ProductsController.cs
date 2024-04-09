using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Entities.ProductAggregate;
using OrderGenius.Core.Interfaces;
using OrderGenius.Dtos;
using OrderGenius.Errors;

namespace OrderGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductService _productService { get; }
        public productController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpPost(nameof(CreateProduct))]
        public async Task<ActionResult<Customer>> CreateProduct(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                var result = await _productService.CreateProductAsync(product);
                if (result == null)
                {
                    return BadRequest(new APIResponce(400, "Something went Wrong"));
                }
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //   "Error storing data in the database");
                return BadRequest(new APIResponce(400, "Something went Wrong"));
            }
            return Ok(productDto);
        }
    }
}

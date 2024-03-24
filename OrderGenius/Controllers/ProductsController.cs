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
        private readonly IMapper mapper;
        private IProductService ProductService { get; }
        public productController(IProductService productService, IMapper _mapper)
        {
            ProductService = productService;
            mapper = _mapper;
        }
        [HttpPost(nameof(CreateProduct))]
        public async Task<ActionResult<Customer>> CreateProduct(ProductDto productDto)
        {
            try
            {
                var product = mapper.Map<Product>(productDto);
                var result = await ProductService.CreateProductAsync(product);
                if (result == null)
                {
                    return BadRequest(new APIResponce(400, "Something went Wrong"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponce(400, "Something went Wrong"));
            }
            return Ok(productDto);
        }
    }
}

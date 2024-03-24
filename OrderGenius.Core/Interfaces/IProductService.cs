
using OrderGenius.Core.Entities.ProductAggregate;

namespace OrderGenius.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);
    }
}

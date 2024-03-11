using OrderGenius.Core.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.IRepository.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int Id);
        Task<IReadOnlyList<Product>> GetListOfProduct();
        Task<IReadOnlyList<ProductType>> GetProductsTypeAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
    }
}

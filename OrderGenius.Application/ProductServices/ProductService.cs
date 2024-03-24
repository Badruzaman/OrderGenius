using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Entities.ProductAggregate;
using OrderGenius.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Application.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                _unitOfWork.repository<Product>().Add(product);
                var result = await _unitOfWork.Complete();
                if (result <= 0)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }
    }
}

using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product customer);
    }
}

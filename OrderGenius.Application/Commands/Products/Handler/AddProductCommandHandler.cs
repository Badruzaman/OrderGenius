using MediatR;
using OrderGenius.Application.Commands.Products.Command;
using OrderGenius.Core.Entities.ProductAggregate;
using OrderGenius.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Application.Commands.Products.Handler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductService _productServicee;
        public AddProductCommandHandler(IProductService productServicee)
        {
            _productServicee = productServicee;
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _productServicee.CreateProductAsync(request.product);
        }

    }
}

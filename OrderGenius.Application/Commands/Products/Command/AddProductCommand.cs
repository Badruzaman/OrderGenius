using MediatR;
using OrderGenius.Core.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Application.Commands.Products.Command
{
    public record AddProductCommand(Product product) : IRequest<Product>;
}

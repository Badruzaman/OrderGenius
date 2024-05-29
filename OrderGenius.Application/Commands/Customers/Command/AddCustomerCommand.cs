using MediatR;
using OrderGenius.Core.Entities.CutomerAggregate;


namespace OrderGenius.Application.Commands.Customers.Command
{
    public record AddCustomerCommand(Customer Customer) : IRequest<Customer>;
}

using MediatR;
using OrderGenius.Application.Commands.Customers.Command;
using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Interfaces;

namespace OrderGenius.Application.Commands.Customers.Handler
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
    {
        private readonly ICustomerService _customerService;
        public AddCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _customerService.CreateCustomerAsync(request.Customer);
        }
    }
}

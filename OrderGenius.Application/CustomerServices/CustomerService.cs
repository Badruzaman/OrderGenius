using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Application.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            try
            {
                _unitOfWork.repository<Customer>().Add(customer);
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
            return customer;
        }
    }
}

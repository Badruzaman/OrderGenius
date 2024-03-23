using OrderGenius.Core.Entities.Identity;
using OrderGenius.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}

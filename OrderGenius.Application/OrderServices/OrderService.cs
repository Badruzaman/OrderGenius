using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Interfaces;

namespace OrderGenius.Application.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            try
            {
                _unitOfWork.repository<Order>().Add(order);
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
            return order;
        }
    }
}

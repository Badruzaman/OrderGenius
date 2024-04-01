using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Interfaces;

namespace OrderGenius.Application.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICodeGeneratorService _codeGeneratorService;
        public OrderService(IUnitOfWork unitOfWork, ICodeGeneratorService codeGeneratorService)
        {
            _unitOfWork = unitOfWork;
            _codeGeneratorService = codeGeneratorService;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            try
            {
                var code = _codeGeneratorService.GenerateCode();
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

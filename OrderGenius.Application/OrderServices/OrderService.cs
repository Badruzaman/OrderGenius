using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Interfaces;
using OrderGenius.Infrastracture.Data;
using OrderGenius.Infrastracture.Migrations;

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
                var codeConfigData = await _unitOfWork.repository<CodeConfig>().GetByIdAsync(1);
                var serialNumber = codeConfigData.Count + 1;
                var code = _codeGeneratorService.GenerateCode(serialNumber);
                codeConfigData.UpdatedAt = DateTime.Now;
                codeConfigData.Count = serialNumber;
                codeConfigData.LastCode = code;

                order.Code = code;
                _unitOfWork.repository<Order>().Add(order);
                _unitOfWork.repository<CodeConfig>().Update(codeConfigData);
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

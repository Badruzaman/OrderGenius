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
                var code = _codeGeneratorService.GenerateCode();
                var counter = await _unitOfWork.repository<CodeConfig>().GetByIdAsync(1);
                var serialNumber = counter == null ? 1 : counter.Count;
                var paddingLeftNumber = 4;
                var formatedCode = code + "-" + _codeGeneratorService.GenerateLeftPadding(serialNumber, paddingLeftNumber);
                var codeConfig = new CodeConfig
                {
                    Count = serialNumber,
                    LastCode = code,
                    UpdatedAt = DateTime.Now
                };
                _unitOfWork.repository<Order>().Add(order);
                if (serialNumber == 1)
                {
                    _unitOfWork.repository<CodeConfig>().Add(codeConfig);
                }
                else
                {
                    codeConfig.Id = 1;
                    _unitOfWork.repository<CodeConfig>().Update(codeConfig);
                }
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


using OrderGenius.Core.Interfaces;
namespace OrderGenius.Application.SerialNumberGenerator
{
    public class CodeGenerator : ICodeGeneratorService
    {
        private int paddingLeftNumber = 4;
        public string GenerateCode(int SerialNo)
        {
            var yearMonthDay = DateTime.Now.ToString("yyyyMMdd");
            var result = "ORD-" + yearMonthDay + "-" + GenerateLeftPadding(SerialNo, paddingLeftNumber);
            return result;
        }
        private string GenerateLeftPadding(int value, int paddingLeftNumber)
        {
            var result = value.ToString().PadLeft(paddingLeftNumber, '0');
            return result;
        }
    }
}

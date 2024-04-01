using Microsoft.EntityFrameworkCore;
using OrderGenius.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Application.SerialNumberGenerator
{
    public class CodeGenerator : ICodeGeneratorService
    {
        public string GenerateCode()
        {
            var yearMonthDay = DateTime.Now.ToString("yyyyMMdd");
            return "ORD-"+ yearMonthDay;
        }
        public string GenerateLeftPadding(int value, int paddingLeftNumber)
        {
            var result = value.ToString().PadLeft(paddingLeftNumber, '0');
            return result;
        }
    }
}

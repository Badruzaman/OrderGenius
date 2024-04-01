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
        private string GeneratePadding(int value)
        {
            var result = value < 10 ? value.ToString().PadLeft(2, '0') : value.ToString();
            return result;
        }
    }
}

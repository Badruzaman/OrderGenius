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
    public class SerialNumberGenerator : ISerialNumberGenerator
    {
        private readonly object _lock = new object();
        public int GetNextSerialNumber()
        {
            lock (_lock)
            {
                //var lastSerialNumber = _dbContext.SerialNumbers.OrderByDescending(s => s.Id).FirstOrDefault();
                //if (lastSerialNumber != null)
                //{
                //    return lastSerialNumber.Value + 1;
                //}
                return 1;
               
            }
        }
       
    }
}

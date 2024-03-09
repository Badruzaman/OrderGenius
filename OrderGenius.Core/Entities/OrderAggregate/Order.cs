using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order() 
        {
            Items = new List<OrderDetail>();
        }  
        public string Code { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<OrderDetail> Items { get; set; }
    }
}

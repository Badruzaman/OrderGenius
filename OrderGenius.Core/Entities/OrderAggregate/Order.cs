using OrderGenius.Core.Entities.CutomerAggregate;
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
            Items = new HashSet<OrderDetail>();
        }  
        public string Code { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId {  get; set; }
        public virtual Customer Customers { get; set; }
        public virtual ICollection<OrderDetail> Items { get; set; }
    }
}

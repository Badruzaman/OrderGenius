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
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId {  get; set; }
        public Customer Customers { get; set; }
        public ICollection<OrderDetail> Items { get; set; }
    }
}

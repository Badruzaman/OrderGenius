using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderGenius.Core.Entities.CutomerAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order() 
        {
            OrderDetails = new List<OrderDetail>();
        }
        [StringLength(20)]
        public string Code { get; set; }
        public DateTime OrderPlaced { get; set; }   
        public DateTime? OrderFulfilled { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal TotalPrice { get; set; }
        public int CustomerId {  get; set; }
        public Customer Customers { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}

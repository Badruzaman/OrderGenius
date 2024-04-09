using OrderGenius.Core.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Entities.OrderAggregate
{
    public class CartItems : BaseEntity
    {
        public int CartId { get; set; }
        public Cart Carts { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }
    }
}

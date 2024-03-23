using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Entities.ProductAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGenius.Dtos
{
    public class OrderDetailDto
    {
        [Column(TypeName = "decimal(6,2)")]
        public decimal Qunatity { get; set; }
        [Column(TypeName = "decimal(6,5)")]
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}

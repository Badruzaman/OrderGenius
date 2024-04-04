using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Entities.ProductAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderGenius.Dtos
{
    public class OrderDetailDto
    {
        [Required]
        public decimal Qunatity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int ProductId { get; set; }
        
    }
}

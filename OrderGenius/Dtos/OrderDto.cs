using OrderGenius.Core.Entities.CutomerAggregate;
using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderGenius.Dtos
{
    public class OrderDto
    {
        public OrderDto()
        {
            Items = new HashSet<OrderDetailDto>();
        }
        [StringLength(20)]
        public string Code { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customers { get; set; }
        public ICollection<OrderDetailDto> Items { get; set; }
    }
}

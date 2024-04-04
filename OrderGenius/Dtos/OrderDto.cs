
using System.ComponentModel.DataAnnotations;
namespace OrderGenius.Dtos
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderDetails = new List<OrderDetailDto>();
        }  
        [Required]
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public decimal TotalPrice {  get; set; }
        [Required]
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}

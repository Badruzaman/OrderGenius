
using System.ComponentModel.DataAnnotations;
namespace OrderGenius.Dtos
{
    public class OrderDto
    {
        public OrderDto()
        {
            Items = new List<OrderDetailDto>();
        }
        [Required]
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public IList<OrderDetailDto> Items { get; set; }
    }
}

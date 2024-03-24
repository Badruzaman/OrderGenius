using OrderGenius.Core.Entities.ProductAggregate;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderGenius.Dtos
{
    public class ProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal? Price { get; set; }
        [StringLength(75)]
        public string? PictureUrl { get; set; }
       
    }
}

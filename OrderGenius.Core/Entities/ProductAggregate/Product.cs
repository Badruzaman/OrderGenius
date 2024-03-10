using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Entities.ProductAggregate
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,5)")]
        public decimal? Price { get; set; }
        [StringLength(75)]
        public string PictureUrl { get; set; } = null!;
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
    }
}

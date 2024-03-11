

using System.ComponentModel.DataAnnotations;

namespace OrderGenius.Core.Entities.ProductAggregate
{
    public class ProductType : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
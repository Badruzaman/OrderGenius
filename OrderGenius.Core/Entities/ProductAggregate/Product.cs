﻿using System;
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
        [Column(TypeName = "decimal(10,2)")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Quantity { get; set; }
        [StringLength(75)]
        public string? PictureUrl { get; set; }
    }
}

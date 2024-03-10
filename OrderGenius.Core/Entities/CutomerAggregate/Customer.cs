using OrderGenius.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Entities.CutomerAggregate
{
    public class Customer : BaseEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string? Street { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(50)]
        public string? State { get; set; }
        [StringLength(5)]
        public string? ZipCode { get; set; }
        [StringLength(20)]
        public string? Email { get; set; }
        [StringLength(15)]
        public string? Phone { get; set; }
    }
}

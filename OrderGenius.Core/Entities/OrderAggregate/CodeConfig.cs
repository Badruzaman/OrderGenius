using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Entities.OrderAggregate
{
    public class CodeConfig : BaseEntity
    {
        public int Count { get; set; }
        [StringLength(50)]
        public string LastCode { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

using OrderGenius.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Entities.OrderAggregate
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new List<CartItems>();
        }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<CartItems> CartItems { get; set; }
    }
}

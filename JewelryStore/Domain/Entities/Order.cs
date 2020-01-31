using System;
using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTimeOffset OrderTime { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}

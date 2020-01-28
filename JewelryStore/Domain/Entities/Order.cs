using System;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTimeOffset OrderTime { get; set; }

        public int BasketId { get; set; }

        public virtual Basket Basket { get; set; }
    }
}

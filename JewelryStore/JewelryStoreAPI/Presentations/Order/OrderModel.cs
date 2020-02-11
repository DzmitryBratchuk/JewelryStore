using System;

namespace JewelryStoreAPI.Presentations.Order
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderTime { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalCost { get; set; }
    }
}

using System;

namespace JewelryStoreAPI.Infrastructure.DTO.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderTime { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalCost { get; set; }
    }
}

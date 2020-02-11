using System.Collections.Generic;

namespace JewelryStoreAPI.Infrastructure.DTO.Order
{
    public class CreateOrderDto
    {
        public int Id { get; set; }
        public IList<int> ProductIds { get; set; }
    }
}

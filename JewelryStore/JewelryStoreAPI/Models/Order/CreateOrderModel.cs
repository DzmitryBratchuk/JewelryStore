using System.Collections.Generic;

namespace JewelryStoreAPI.Models.Order
{
    public class CreateOrderModel
    {
        public IList<int> ProductIds { get; set; }
    }
}

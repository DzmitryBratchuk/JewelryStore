using System.Collections.Generic;

namespace JewelryStoreAPI.Presentations.Order
{
    public class CreateOrderModel
    {
        public IList<int> ProductIds { get; set; }
    }
}

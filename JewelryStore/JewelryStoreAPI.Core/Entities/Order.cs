using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderTime { get; set; }

        public int BasketID { get; set; }

        public virtual Basket Basket { get; set; }
    }
}

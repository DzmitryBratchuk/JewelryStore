using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Entities
{
    public class ProductBasket
    {
        public int ProductId { get; set; }
        public int BasketId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Basket Basket { get; set; }
    }
}

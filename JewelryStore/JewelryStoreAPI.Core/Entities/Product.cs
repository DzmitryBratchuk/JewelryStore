using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Entities
{
    public class Product
    {
        public Product()
        {
            ProductBaskets = new HashSet<ProductBasket>();
        }

        public int Id { get; set; }

        public int? BijouterieId { get; set; }
        public int? PreciousMetalStuffId { get; set; }
        public int? WristwatchId { get; set; }

        public virtual Bijouterie Bijouterie { get; set; }
        public virtual PreciousMetalStuff PreciousMetalStuff { get; set; }
        public virtual Wristwatch Wristwatch { get; set; }

        public virtual ICollection<ProductBasket> ProductBaskets { get; set; }
    }
}

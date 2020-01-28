using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            ProductBaskets = new HashSet<ProductBasket>();
        }

        public int Id { get; set; }

        public int? BijouterieId { get; set; }

        public int? PreciousMetalMaterialId { get; set; }

        public int? WatchId { get; set; }

        public virtual Bijouterie Bijouterie { get; set; }

        public virtual PreciousMetalMaterial PreciousMetalMaterial { get; set; }

        public virtual Watch Watch { get; set; }

        public virtual ICollection<ProductBasket> ProductBaskets { get; set; }
    }
}

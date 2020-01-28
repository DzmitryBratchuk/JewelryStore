using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class PreciousMetalMaterial
    {
        public PreciousMetalMaterial()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public PreciousMetalMaterialType PreciousMetalMaterialType { get; set; } 

        public MetalType MetalType { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Country { get; set; }

        public decimal Cost { get; set; }

        public int Amount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Entities
{
    public class PreciousMetalStuff
    {
        public PreciousMetalStuff()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public PreciousMetalStuffTypes PreciousMetalStuffType { get; set; } 
        public MetalTypes MetalType { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

    public enum PreciousMetalStuffTypes
    {
        Bracelet,
        Crown,
        Earring,
        Medallion,
        Ring,
        Plate,
        Spoon,
        Fork,
        Coin
    }

    public enum MetalTypes
    {
        Silver,
        Gold,
        Platinum
    }
}

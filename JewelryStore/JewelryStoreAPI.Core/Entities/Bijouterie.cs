using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Entities
{
    public class Bijouterie
    {
        public Bijouterie()
        {
            Products = new HashSet<Product>();
        }

        public int Id {get;set;}

        public BijouterieTypes BijouterieType { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

    public enum BijouterieTypes
    {       
        Bracelet,
        Crown,
        Earring,
        Medallion,
        Ring
    }
}

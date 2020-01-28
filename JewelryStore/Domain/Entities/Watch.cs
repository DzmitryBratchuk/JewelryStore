using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Watch
    {
        public Watch()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Country { get; set; }

        public decimal Cost { get; set; }

        public int Amount { get; set; }

        public int DiameterMM { get; set; }

        public Color CaseColor { get; set; }

        public Color DialColor { get; set; }

        public Color StrapColor { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

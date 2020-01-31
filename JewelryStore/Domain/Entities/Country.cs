using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Country
    {
        public Country()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

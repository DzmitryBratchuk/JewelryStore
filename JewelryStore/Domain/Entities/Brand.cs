using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

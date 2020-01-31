using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            ProductBaskets = new HashSet<ProductBasket>();
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Amount { get; set; }

        public int BrandId { get; set; }

        public int CountryId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<ProductBasket> ProductBaskets { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}

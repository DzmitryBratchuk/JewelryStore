using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Basket
    {
        public Basket()
        {
            ProductBaskets = new HashSet<ProductBasket>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ProductBasket> ProductBaskets { get; set; }
    }
}

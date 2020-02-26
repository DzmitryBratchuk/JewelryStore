namespace JewelryStoreAPI.Domain.Entities
{
    public class ProductBasket
    {
        public int ProductId { get; set; }

        public int BasketId { get; set; }

        public int ProductCount { get; set; }

        public virtual Product Product { get; set; }

        public virtual Basket Basket { get; set; }
    }
}

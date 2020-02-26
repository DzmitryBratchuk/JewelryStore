namespace JewelryStoreAPI.Infrastructure.DTO.ProductBasket
{
    public class ProductBasketDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductCost { get; set; }
        public int ProductCountInStore { get; set; }
        public int ProductCountInBasket { get; set; }
    }
}

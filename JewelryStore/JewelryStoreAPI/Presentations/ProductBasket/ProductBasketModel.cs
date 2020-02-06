namespace JewelryStoreAPI.Presentations.ProductBasket
{
    public class ProductBasketModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductCost { get; set; }
        public int ProductCountInStore { get; set; }
        public int ProductCountInBasket { get; set; }
    }
}

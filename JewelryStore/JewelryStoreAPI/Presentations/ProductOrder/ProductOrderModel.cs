namespace JewelryStoreAPI.Presentations.ProductOrder
{
    public class ProductOrderModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCountry { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductCost { get; set; }
    }
}

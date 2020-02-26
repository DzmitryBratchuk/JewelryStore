namespace JewelryStoreAPI.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string BrandName { get; set; }
        public string CountryName { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
    }
}

namespace JewelryStoreAPI.Models.PreciousItem
{
    public class PreciousItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CountryName { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public string PreciousItemTypeName { get; set; }
        public string MetalType { get; set; }
    }
}

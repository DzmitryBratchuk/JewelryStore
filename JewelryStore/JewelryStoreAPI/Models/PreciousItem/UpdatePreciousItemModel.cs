namespace JewelryStoreAPI.Models.PreciousItem
{
    public class UpdatePreciousItemModel
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int PreciousItemTypeId { get; set; }
    }
}

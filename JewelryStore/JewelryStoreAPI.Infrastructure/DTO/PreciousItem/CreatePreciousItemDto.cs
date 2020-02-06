namespace JewelryStoreAPI.Infrastructure.DTO.PreciousItem
{
    public class CreatePreciousItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int PreciousItemTypeId { get; set; }
    }
}

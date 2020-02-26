using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Infrastructure.DTO.PreciousItem
{
    public class PreciousItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CountryName { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public string PreciousItemTypeName { get; set; }
        public MetalType MetalType { get; set; }
    }
}

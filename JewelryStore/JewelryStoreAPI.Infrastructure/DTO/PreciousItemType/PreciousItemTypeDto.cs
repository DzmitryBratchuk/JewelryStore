using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Infrastructure.DTO.PreciousItemType
{
    public class PreciousItemTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MetalType MetalType { get; set; }
    }
}

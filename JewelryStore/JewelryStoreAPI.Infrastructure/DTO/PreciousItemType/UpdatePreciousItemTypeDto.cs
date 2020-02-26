using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Infrastructure.DTO.PreciousItemType
{
    public class UpdatePreciousItemTypeDto
    {
        public string Name { get; set; }
        public MetalType MetalType { get; set; }
    }
}

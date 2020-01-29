namespace JewelryStoreAPI.Domain.Entities
{
    public class PreciousMetalMaterial : Product
    {
        public int MetalTypeId { get; set; }

        public int PreciousMetalMaterialTypeId { get; set; }

        public virtual MetalType MetalType { get; set; }

        public virtual PreciousMetalMaterialType PreciousMetalMaterialType { get; set; }
    }
}

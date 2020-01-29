using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class MetalType
    {
        public MetalType()
        {
            PreciousMetalMaterials = new HashSet<PreciousMetalMaterial>();
        }

        public int Id { get; set; }

        public string MetalTypeName { get; set; }

        public virtual ICollection<PreciousMetalMaterial> PreciousMetalMaterials { get; set; }
    }
}

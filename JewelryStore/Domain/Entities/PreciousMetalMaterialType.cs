using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class PreciousMetalMaterialType
    {
        public PreciousMetalMaterialType()
        {
            PreciousMetalMaterials = new HashSet<PreciousMetalMaterial>();
        }

        public int Id { get; set; }

        public string PreciousMetalMaterialTypeName { get; set; }

        public virtual ICollection<PreciousMetalMaterial> PreciousMetalMaterials { get; set; }
    }
}

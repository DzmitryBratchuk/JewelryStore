using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class PreciousItemType
    {
        public PreciousItemType()
        {
            PreciousItems = new HashSet<PreciousItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public MetalType? MetalType { get; set; }

        public virtual ICollection<PreciousItem> PreciousItems { get; set; }
    }
}

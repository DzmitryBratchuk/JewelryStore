using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Bijouterie : Product
    {
        public int BijouterieTypeId { get; set; }

        public virtual BijouterieType BijouterieType { get; set; }
    }
}

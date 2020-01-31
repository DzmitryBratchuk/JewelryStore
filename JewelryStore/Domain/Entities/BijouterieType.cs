using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class BijouterieType
    {
        public BijouterieType()
        {
            Bijouteries = new HashSet<Bijouterie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Bijouterie> Bijouteries { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Entities
{
    public class BijouterieType
    {
        public BijouterieType()
        {
            Bijouteries = new HashSet<Bijouterie>();
        }

        public int Id { get; set; }
        public string BijouterieTypeName { get; set; }

        public virtual ICollection<Bijouterie> Bijouteries { get; set; }
    }
}

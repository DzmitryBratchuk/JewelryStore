using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Color
    {
        public Color()
        {
            WatchesWithCaseColors = new HashSet<Watch>();
            WatchesWithDialColors = new HashSet<Watch>();
            WatchesWithStrapColors = new HashSet<Watch>();
        }

        public int Id { get; set; }

        public string ColorName { get; set; }

        public virtual ICollection<Watch> WatchesWithCaseColors { get; set; }

        public virtual ICollection<Watch> WatchesWithDialColors { get; set; }

        public virtual ICollection<Watch> WatchesWithStrapColors { get; set; }
    }
}

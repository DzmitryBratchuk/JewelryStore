using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class Watch : Product
    {
        public int DiameterMM { get; set; }

        public int? CaseColorId { get; set; }

        public int? DialColorId { get; set; }

        public int? StrapColorId { get; set; }

        public virtual Color CaseColor { get; set; }

        public virtual Color DialColor { get; set; }

        public virtual Color StrapColor { get; set; }
    }
}

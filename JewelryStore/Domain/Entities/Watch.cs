namespace JewelryStoreAPI.Domain.Entities
{
    public class Watch : Product
    {
        public int DiameterMM { get; set; }

        public Color CaseColorId { get; set; }

        public Color DialColorId { get; set; }

        public Color StrapColorId { get; set; }
    }
}

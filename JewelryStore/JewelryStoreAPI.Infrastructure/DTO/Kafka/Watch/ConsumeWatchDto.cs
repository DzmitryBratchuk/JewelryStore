using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Infrastructure.DTO.Kafka.Watch
{
    public class ConsumeWatchDto
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int DiameterInMillimeters { get; set; }
        public Color CaseColor { get; set; }
        public Color DialColor { get; set; }
        public Color StrapColor { get; set; }
    }
}

using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Infrastructure.DTO.Watch
{
    public class WatchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CountryName { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int DiameterInMillimeters { get; set; }
        public Color CaseColor { get; set; }
        public Color DialColor { get; set; }
        public Color StrapColor { get; set; }
    }
}

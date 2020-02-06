using JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Infrastructure.DTO.Watch
{
    public class CreateWatchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int Diameter { get; set; }
        public Color CaseColor { get; set; }
        public Color DialColor { get; set; }
        public Color StrapColor { get; set; }
    }
}

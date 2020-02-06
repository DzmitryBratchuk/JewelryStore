namespace JewelryStoreAPI.Presentations.Watch
{
    public class UpdateWatchModel
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int Diameter { get; set; }
        public string CaseColor { get; set; }
        public string DialColor { get; set; }
        public string StrapColor { get; set; }
    }
}

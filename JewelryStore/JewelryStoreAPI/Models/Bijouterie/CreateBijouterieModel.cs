namespace JewelryStoreAPI.Models.Bijouterie
{
    public class CreateBijouterieModel
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int BijouterieTypeId { get; set; }
    }
}

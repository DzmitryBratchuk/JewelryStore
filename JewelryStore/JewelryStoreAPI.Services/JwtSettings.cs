namespace JewelryStoreAPI.Services
{
    public class JwtSettings
    {
        public string Secret { get; set; }

        public int Lifetime { get; set; }
    }
}

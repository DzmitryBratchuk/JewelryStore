namespace JewelryStoreAPI.Infrastructure.Common
{
    public class RedisConfiguration
    {
        public string ServerUrl { get; set; }

        public int CacheExpirationInSeconds { get; set; }

        public CacheKeys CacheKeys { get; set; }
    }
}

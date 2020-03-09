namespace JewelryStoreAPI.Infrastructure.Common
{
    public class KafkaConfiguration
    {
        public string ServerUrl { get; set; }

        public string GroupId { get; set; }

        public Topics Topics { get; set; }
    }
}

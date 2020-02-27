namespace JewelryStoreAPI.Common
{
    public class KafkaSettings
    {
        public string ServerUrl { get; set; }

        public string GroupId { get; set; }

        public Topics Topics { get; set; }
    }
}

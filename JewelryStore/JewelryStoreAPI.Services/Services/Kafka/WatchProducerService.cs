using Confluent.Kafka;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.Kafka.Watch;
using JewelryStoreAPI.Infrastructure.Interfaces.Services.Kafka;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services.Kafka
{
    public class WatchProducerService : IWatchProducerService
    {
        private readonly IProducer<Null, string> _producer;
        private readonly KafkaConfiguration _kafkaConfiguration;

        public WatchProducerService(IProducer<Null, string> producer, IOptions<KafkaConfiguration> kafkaConfiguration)
        {
            _producer = producer;
            _kafkaConfiguration = kafkaConfiguration.Value;
        }

        public async Task ProduceAsync(ProduceWatchDto produceWatch)
        {
            var jsonString = JsonSerializer.Serialize(produceWatch);

            await _producer.ProduceAsync(_kafkaConfiguration.Topics.CreateWatch, new Message<Null, string> { Value = jsonString });
        }
    }
}

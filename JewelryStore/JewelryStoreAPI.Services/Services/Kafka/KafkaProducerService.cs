using Confluent.Kafka;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using JewelryStoreAPI.Infrastructure.Interfaces.Services.Kafka;
using System.Text.Json;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services.Kafka
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerService(IProducer<Null, string> producer)
        {
            _producer = producer;
        }

        public async Task<DeliveryResult<Null, string>> Produce(CreateWatchDto createWatch, string topicName)
        {
            var jsonString = JsonSerializer.Serialize(createWatch);

            return await _producer.ProduceAsync(topicName, new Message<Null, string> { Value = jsonString });
        }
    }
}

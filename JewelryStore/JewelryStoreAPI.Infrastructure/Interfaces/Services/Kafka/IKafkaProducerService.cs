using Confluent.Kafka;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services.Kafka
{
    public interface IKafkaProducerService
    {
        Task<DeliveryResult<Null, string>> Produce(CreateWatchDto createWatch, string topicName);
    }
}

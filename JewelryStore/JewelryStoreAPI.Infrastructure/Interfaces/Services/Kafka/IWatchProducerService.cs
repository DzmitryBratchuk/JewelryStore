using JewelryStoreAPI.Infrastructure.DTO.Kafka.Watch;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services.Kafka
{
    public interface IWatchProducerService
    {
        Task ProduceAsync(ProduceWatchDto produceWatch);
    }
}

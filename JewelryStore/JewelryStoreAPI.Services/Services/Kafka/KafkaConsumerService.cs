using AutoMapper;
using Confluent.Kafka;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services.Kafka;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class KafkaConsumerService : BackgroundService, IKafkaConsumerService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly IWatchRepository _watchRepository;
        private readonly IMapper _mapper;

        public KafkaConsumerService(IConsumer<Ignore, string> consumer, IWatchRepository watchRepository, IMapper mapper)
        {
            _consumer = consumer;
            _watchRepository = watchRepository;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume();

                var createWatch = JsonSerializer.Deserialize<CreateWatchDto>(consumeResult.Value);

                var entity = _mapper.Map<Watch>(createWatch);

                await _watchRepository.Create(entity);
                await _watchRepository.SaveChangesAsync();
            }
        }
    }
}

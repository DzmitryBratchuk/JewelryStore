using AutoMapper;
using Confluent.Kafka;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.Kafka.Watch;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class WatchesConsumerService : BackgroundService, IWatchConsumerService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly IWatchRepository _watchRepository;
        private readonly IMapper _mapper;
        private readonly KafkaConfiguration _kafkaConfiguration;

        public WatchesConsumerService(
            IConsumer<Ignore, string> consumer,
            IWatchRepository watchRepository,
            IMapper mapper,
            IOptions<KafkaConfiguration> kafkaConfiguration)
        {
            _consumer = consumer;
            _watchRepository = watchRepository;
            _mapper = mapper;
            _kafkaConfiguration = kafkaConfiguration.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_kafkaConfiguration.Topics.CreateWatch);

            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume();

                var consumeWatch = JsonSerializer.Deserialize<ConsumeWatchDto>(consumeResult.Value);

                var entity = _mapper.Map<Watch>(consumeWatch);

                await _watchRepository.Create(entity);
                await _watchRepository.SaveChangesAsync();
            }
        }
    }
}

using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.Redis;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services.Redis
{
    public class WatchCacheService : IWatchCacheService
    {
        private readonly IWatchRepository _watchRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly RedisConfiguration _redisConfiguration;

        public WatchCacheService(
            IWatchRepository watchRepository,
            IMapper mapper,
            IDistributedCache cache,
            IOptions<RedisConfiguration> redisConfiguration)
        {
            _watchRepository = watchRepository;
            _mapper = mapper;
            _cache = cache;
            _redisConfiguration = redisConfiguration.Value;
        }

        public async Task<IList<WatchCacheDto>> GetAllAsync()
        {
            var cachedWatches = await _cache.GetStringAsync(_redisConfiguration.CacheKeys.GetAllWatches);

            if (cachedWatches == null)
            {
                var entities = await _watchRepository.GetAll();

                await SetCacheAsync(entities);

                return _mapper.Map<IList<WatchCacheDto>>(entities);
            }

            return JsonSerializer.Deserialize<IList<WatchCacheDto>>(cachedWatches);
        }

        private async Task SetCacheAsync(IList<Watch> entities)
        {
            var cachedWatches = JsonSerializer.Serialize(_mapper.Map<IList<WatchCacheDto>>(entities));

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(_redisConfiguration.CacheExpirationInSeconds));

            await _cache.SetStringAsync(_redisConfiguration.CacheKeys.GetAllWatches, cachedWatches, options);
        }
    }
}

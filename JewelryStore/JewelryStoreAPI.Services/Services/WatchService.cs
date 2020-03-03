using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class WatchService : IWatchService
    {
        private readonly IWatchRepository _repository;
        private readonly IMapper _mapper;

        public WatchService(IWatchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<WatchDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<WatchDto> GetByIdAsync(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<WatchDto>(entity);
        }

        public async Task<IList<WatchDto>> GetAllByBrandIdAsync(int brandId)
        {
            var entities = await _repository.GetAllByBrandIdAsync(brandId);

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<IList<WatchDto>> GetAllByCountryIdAsync(int countryId)
        {
            var entities = await _repository.GetAllByCountryIdAsync(countryId);

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<IList<WatchDto>> GetAllByDiameterAsync(int diameterInMillimeters)
        {
            var entities = await _repository.GetAllByDiameterAsync(diameterInMillimeters);

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<WatchDto> CreateAsync(CreateWatchDto createWatch)
        {
            var entity = _mapper.Map<Watch>(createWatch);

            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();

            var createdEntity = await GetEntityById(entity.Id);

            return _mapper.Map<WatchDto>(createdEntity);
        }

        public async Task UpdateAsync(int id, UpdateWatchDto updateWatch)
        {
            var entity = await GetEntityById(id);

            _mapper.Map(updateWatch, entity);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<Watch> GetEntityById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(Watch), id, ErrorCode.NotFound);
            }

            return entity;
        }
    }
}

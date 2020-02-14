using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
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

        public async Task<IList<WatchDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<WatchDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<WatchDto>(entity);
        }

        public async Task<IList<WatchDto>> GetAllByBrandId(int brandId)
        {
            var entities = await _repository.GetAllByBrandId(brandId);

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<IList<WatchDto>> GetAllByCountryId(int countryId)
        {
            var entities = await _repository.GetAllByCountryId(countryId);

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<IList<WatchDto>> GetAllByDiameter(int diameterInMillimeters)
        {
            var entities = await _repository.GetAllByDiameter(diameterInMillimeters);

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task<WatchDto> Create(CreateWatchDto createWatch)
        {
            var entity = _mapper.Map<Watch>(createWatch);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            var createdEntity = await GetEntityById(entity.Id);

            return _mapper.Map<WatchDto>(createdEntity);
        }

        public async Task Update(int id, UpdateWatchDto updateWatch)
        {
            var entity = await GetEntityById(id);

            _mapper.Map(updateWatch, entity);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemoveWatchDto removeWatch)
        {
            var entity = await GetEntityById(removeWatch.Id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<Watch> GetEntityById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Watch), id);
            }

            return entity;
        }
    }
}

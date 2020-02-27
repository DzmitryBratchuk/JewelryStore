using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItem;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class PreciousItemService : IPreciousItemService
    {
        private readonly IPreciousItemRepository _repository;
        private readonly IMapper _mapper;

        public PreciousItemService(IPreciousItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<PreciousItemDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<PreciousItemDto> GetByIdAsync(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<PreciousItemDto>(entity);
        }

        public async Task<IList<PreciousItemDto>> GetAllByBrandIdAsync(int brandId)
        {
            var entities = await _repository.GetAllByBrandIdAsync(brandId);

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<IList<PreciousItemDto>> GetAllByCountryIdAsync(int countryId)
        {
            var entities = await _repository.GetAllByCountryIdAsync(countryId);

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<IList<PreciousItemDto>> GetAllByPreciousItemTypeIdAsync(int preciousItemTypeId)
        {
            var entities = await _repository.GetAllByPreciousItemTypeIdAsync(preciousItemTypeId);

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<PreciousItemDto> CreateAsync(CreatePreciousItemDto createPreciousItem)
        {
            var entity = _mapper.Map<PreciousItem>(createPreciousItem);

            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();

            var createdEntity = await GetEntityById(entity.Id);

            return _mapper.Map<PreciousItemDto>(createdEntity);
        }

        public async Task UpdateAsync(int id, UpdatePreciousItemDto updatePreciousItem)
        {
            var entity = await GetEntityById(id);

            _mapper.Map(updatePreciousItem, entity);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<PreciousItem> GetEntityById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(PreciousItem), id, ErrorCode.NotFound);
            }

            return entity;
        }
    }
}

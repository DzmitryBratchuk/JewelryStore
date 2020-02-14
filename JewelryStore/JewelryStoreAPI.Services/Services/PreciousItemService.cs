using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItem;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
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

        public async Task<IList<PreciousItemDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<PreciousItemDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<PreciousItemDto>(entity);
        }

        public async Task<IList<PreciousItemDto>> GetAllByBrandId(int brandId)
        {
            var entities = await _repository.GetAllByBrandId(brandId);

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<IList<PreciousItemDto>> GetAllByCountryId(int countryId)
        {
            var entities = await _repository.GetAllByCountryId(countryId);

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<IList<PreciousItemDto>> GetAllByPreciousItemTypeId(int preciousItemTypeId)
        {
            var entities = await _repository.GetAllByPreciousItemTypeId(preciousItemTypeId);

            return _mapper.Map<IList<PreciousItemDto>>(entities);
        }

        public async Task<PreciousItemDto> Create(CreatePreciousItemDto createPreciousItem)
        {
            var entity = _mapper.Map<PreciousItem>(createPreciousItem);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            var createdEntity = await GetEntityById(entity.Id);

            return _mapper.Map<PreciousItemDto>(createdEntity);
        }

        public async Task Update(int id, UpdatePreciousItemDto updatePreciousItem)
        {
            var entity = await GetEntityById(id);

            _mapper.Map(updatePreciousItem, entity);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemovePreciousItemDto removePreciousItem)
        {
            var entity = await GetEntityById(removePreciousItem.Id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<PreciousItem> GetEntityById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItem), id);
            }

            return entity;
        }
    }
}

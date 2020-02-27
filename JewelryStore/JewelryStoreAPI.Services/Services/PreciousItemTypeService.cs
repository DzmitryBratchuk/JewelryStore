using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class PreciousItemTypeService : IPreciousItemTypeService
    {
        private readonly IPreciousItemTypeRepository _repository;
        private readonly IMapper _mapper;

        public PreciousItemTypeService(IPreciousItemTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<PreciousItemTypeDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IList<PreciousItemTypeDto>>(entities);
        }

        public async Task<PreciousItemTypeDto> GetByIdAsync(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<PreciousItemTypeDto>(entity);
        }

        public async Task<IList<PreciousItemTypeDto>> GetAllByMetalTypeAsync(MetalType metalType)
        {
            var entities = await _repository.GetAllByMetalTypeAsync(metalType);

            return _mapper.Map<IList<PreciousItemTypeDto>>(entities);
        }

        public async Task<PreciousItemTypeDto> CreateAsync(CreatePreciousItemTypeDto createPreciousItemType)
        {
            var entity = _mapper.Map<PreciousItemType>(createPreciousItemType);

            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<PreciousItemTypeDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdatePreciousItemTypeDto updatePreciousItemType)
        {
            var entity = await GetEntityById(id);

            entity.Name = updatePreciousItemType.Name;
            entity.MetalType = updatePreciousItemType.MetalType;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<PreciousItemType> GetEntityById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(PreciousItemType), id, ErrorCode.NotFound);
            }

            return entity;
        }
    }
}

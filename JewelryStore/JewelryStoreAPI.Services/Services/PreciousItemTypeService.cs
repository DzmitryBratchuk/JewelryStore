using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
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

        public async Task<IList<PreciousItemTypeDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<PreciousItemTypeDto>>(entities);
        }

        public async Task<PreciousItemTypeDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<PreciousItemTypeDto>(entity);
        }

        public async Task<IList<PreciousItemTypeDto>> GetAllByMetalType(MetalType metalType)
        {
            var entities = await _repository.GetAllByMetalType(metalType);

            return _mapper.Map<IList<PreciousItemTypeDto>>(entities);
        }

        public async Task<PreciousItemTypeDto> Create(CreatePreciousItemTypeDto createPreciousItemType)
        {
            var entity = _mapper.Map<PreciousItemType>(createPreciousItemType);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<PreciousItemTypeDto>(entity);
        }

        public async Task Update(int id, UpdatePreciousItemTypeDto updatePreciousItemType)
        {
            var entity = await GetEntityById(id);

            entity.Name = updatePreciousItemType.Name;
            entity.MetalType = updatePreciousItemType.MetalType;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<PreciousItemType> GetEntityById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItemType), id);
            }

            return entity;
        }
    }
}

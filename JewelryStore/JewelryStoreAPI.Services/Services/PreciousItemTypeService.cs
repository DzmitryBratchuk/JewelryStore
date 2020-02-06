using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System;
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
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItemType), id);
            }

            return _mapper.Map<PreciousItemTypeDto>(entity);
        }

        public async Task<IList<PreciousItemTypeDto>> GetAllByMetalTypeName(string metalTypeName)
        {
            var result = Enum.TryParse(metalTypeName, out MetalType metalType);

            if (!result)
            {
                throw new BadRequestException($" '{nameof(MetalType)}' has a range of values which does not include '{metalTypeName}'");
            }

            var entities = await _repository.GetAllByMetalType(metalType);

            return _mapper.Map<IList<PreciousItemTypeDto>>(entities);
        }

        public async Task Create(CreatePreciousItemTypeDto createPreciousItemType)
        {
            var entity = _mapper.Map<PreciousItemType>(createPreciousItemType);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            createPreciousItemType.Id = entity.Id;
        }

        public async Task Update(int id, UpdatePreciousItemTypeDto updatePreciousItemType)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItemType), id);
            }

            entity.Name = updatePreciousItemType.Name;
            entity.MetalType = updatePreciousItemType.MetalType;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemovePreciousItemTypeDto removePreciousItemType)
        {
            var entity = await _repository.GetById(removePreciousItemType.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItemType), removePreciousItemType.Id);
            }

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }
    }
}

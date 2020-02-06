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
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItem), id);
            }

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

        public async Task Create(CreatePreciousItemDto createPreciousItem)
        {
            var entity = _mapper.Map<PreciousItem>(createPreciousItem);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            createPreciousItem.Id = entity.Id;
        }

        public async Task Update(int id, UpdatePreciousItemDto updatePreciousItem)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItem), id);
            }

            entity.Name = updatePreciousItem.Name;
            entity.Cost = updatePreciousItem.Cost;
            entity.Amount = updatePreciousItem.Amount;
            entity.BrandId = updatePreciousItem.BrandId;
            entity.CountryId = updatePreciousItem.CountryId;
            entity.PreciousItemTypeId = updatePreciousItem.PreciousItemTypeId;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemovePreciousItemDto removePreciousItem)
        {
            var entity = await _repository.GetById(removePreciousItem.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PreciousItem), removePreciousItem.Id);
            }

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }
    }
}

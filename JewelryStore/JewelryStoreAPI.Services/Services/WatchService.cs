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
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Watch), id);
            }

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

        public async Task<IList<WatchDto>> GetAllByDiameter(int diameter)
        {
            var entities = await _repository.GetAllByDiameter(diameter);

            return _mapper.Map<IList<WatchDto>>(entities);
        }

        public async Task Create(CreateWatchDto createWatch)
        {
            var entity = _mapper.Map<Watch>(createWatch);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            createWatch.Id = entity.Id;
        }

        public async Task Update(int id, UpdateWatchDto updateWatch)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Watch), id);
            }

            entity.Name = updateWatch.Name;
            entity.Cost = updateWatch.Cost;
            entity.Amount = updateWatch.Amount;
            entity.BrandId = updateWatch.BrandId;
            entity.CountryId = updateWatch.CountryId;
            entity.DiameterMM = updateWatch.Diameter;
            entity.CaseColorId = updateWatch.CaseColor;
            entity.DialColorId = updateWatch.DialColor;
            entity.StrapColorId = updateWatch.StrapColor;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemoveWatchDto removeWatch)
        {
            var entity = await _repository.GetById(removeWatch.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Watch), removeWatch.Id);
            }

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }
    }
}

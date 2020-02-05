using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class BijouterieService : IBijouterieService
    {
        private readonly IBijouterieRepository _repository;
        private readonly IMapper _mapper;

        public BijouterieService(IBijouterieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<BijouterieDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task<BijouterieDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bijouterie), id);
            }

            return _mapper.Map<BijouterieDto>(entity);
        }

        public async Task<IList<BijouterieDto>> GetAllByBijouterieTypeId(int id)
        {
            var entities = await _repository.GetAllByBijouterieTypeId(id);

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task<IList<BijouterieDto>> GetAllByBrandId(int id)
        {
            var entities = await _repository.GetAllByBrandId(id);

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task<IList<BijouterieDto>> GetAllByCountryId(int id)
        {
            var entities = await _repository.GetAllByCountryId(id);

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task Create(CreateBijouterieDto createBijouterie)
        {
            var entity = _mapper.Map<Bijouterie>(createBijouterie);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            createBijouterie.Id = entity.Id;
        }

        public async Task Update(int id, UpdateBijouterieDto updateBijouterie)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bijouterie), id);
            }

            entity.Name = updateBijouterie.Name;
            entity.Cost = updateBijouterie.Cost;
            entity.Amount = updateBijouterie.Amount;
            entity.BrandId = updateBijouterie.BrandId;
            entity.CountryId = updateBijouterie.CountryId;
            entity.BijouterieTypeId = updateBijouterie.BijouterieTypeId;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemoveBijouterieDto removeBijouterie)
        {
            var entity = await _repository.GetById(removeBijouterie.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bijouterie), removeBijouterie.Id);
            }

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }
    }
}

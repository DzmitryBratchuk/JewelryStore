using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Services.Exceptions;
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

        public async Task<IList<BijouterieDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task<BijouterieDto> GetByIdAsync(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<BijouterieDto>(entity);
        }

        public async Task<IList<BijouterieDto>> GetAllByBijouterieTypeIdAsync(int id)
        {
            var entities = await _repository.GetAllByBijouterieTypeIdAsync(id);

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task<IList<BijouterieDto>> GetAllByBrandIdAsync(int id)
        {
            var entities = await _repository.GetAllByBrandIdAsync(id);

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task<IList<BijouterieDto>> GetAllByCountryIdAsync(int id)
        {
            var entities = await _repository.GetAllByCountryIdAsync(id);

            return _mapper.Map<IList<BijouterieDto>>(entities);
        }

        public async Task<BijouterieDto> CreateAsync(CreateBijouterieDto createBijouterie)
        {
            var entity = _mapper.Map<Bijouterie>(createBijouterie);

            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();

            var createdEntity = await GetEntityById(entity.Id);

            return _mapper.Map<BijouterieDto>(createdEntity);
        }

        public async Task UpdateAsync(int id, UpdateBijouterieDto updateBijouterie)
        {
            var entity = await GetEntityById(id);

            _mapper.Map(updateBijouterie, entity);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<Bijouterie> GetEntityById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(Bijouterie), id, ErrorCode.NotFound);
            }

            return entity;
        }
    }
}

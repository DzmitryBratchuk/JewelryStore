using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.BijouterieType;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class BijouterieTypeService : IBijouterieTypeService
    {
        private readonly IBijouterieTypeRepository _repository;
        private readonly IMapper _mapper;

        public BijouterieTypeService(IBijouterieTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<BijouterieTypeDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IList<BijouterieTypeDto>>(entities);
        }

        public async Task<BijouterieTypeDto> GetByIdAsync(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<BijouterieTypeDto>(entity);
        }

        public async Task<BijouterieTypeDto> CreateAsync(CreateBijouterieTypeDto createBijouterieType)
        {
            var entity = _mapper.Map<BijouterieType>(createBijouterieType);

            await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<BijouterieTypeDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateBijouterieTypeDto updateBijouterieType)
        {
            var entity = await GetEntityById(id);

            entity.Name = updateBijouterieType.Name;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<BijouterieType> GetEntityById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new BaseBusinessJewelryStoreException(nameof(BijouterieType), id, ErrorCode.NotFound);
            }

            return entity;
        }
    }
}

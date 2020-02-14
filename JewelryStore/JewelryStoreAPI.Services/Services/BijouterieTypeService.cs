using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.BijouterieType;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
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

        public async Task<IList<BijouterieTypeDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<BijouterieTypeDto>>(entities);
        }

        public async Task<BijouterieTypeDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<BijouterieTypeDto>(entity);
        }

        public async Task<BijouterieTypeDto> Create(CreateBijouterieTypeDto createBijouterieType)
        {
            var entity = _mapper.Map<BijouterieType>(createBijouterieType);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<BijouterieTypeDto>(entity);
        }

        public async Task Update(int id, UpdateBijouterieTypeDto updateBijouterieType)
        {
            var entity = await GetEntityById(id);

            entity.Name = updateBijouterieType.Name;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemoveBijouterieTypeDto removeBijouterieType)
        {
            var entity = await GetEntityById(removeBijouterieType.Id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<BijouterieType> GetEntityById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(BijouterieType), id);
            }

            return entity;
        }
    }
}

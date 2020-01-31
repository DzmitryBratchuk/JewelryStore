using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.CommandsDTO;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Infrastructure.QueriesDTO;
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

        public async Task<IList<BijouterieQueryDTO>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<BijouterieQueryDTO>>(entities);
        }

        public async Task<BijouterieQueryDTO> GetById(object id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
                throw new NotFoundException(nameof(Bijouterie), id);
            else
                return _mapper.Map<BijouterieQueryDTO>(entity);
        }

        public async Task<IList<BijouterieQueryDTO>> GetAllByBijouterieTypeId(int id)
        {
            var entities = await _repository.GetAllByBijouterieTypeId(id);

            return _mapper.Map<IList<BijouterieQueryDTO>>(entities);
        }

        public async Task<IList<BijouterieQueryDTO>> GetAllByBrandId(int id)
        {
            var entities = await _repository.GetAllByBrandId(id);

            return _mapper.Map<IList<BijouterieQueryDTO>>(entities);
        }

        public async Task<IList<BijouterieQueryDTO>> GetAllByCountryId(int id)
        {
            var entities = await _repository.GetAllByCountryId(id);

            return _mapper.Map<IList<BijouterieQueryDTO>>(entities);
        }

        public async Task Create(BijouterieCommandDTO bijouterieCommand)
        {
            var entity = _mapper.Map<Bijouterie>(bijouterieCommand);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            bijouterieCommand.Id = entity.Id;
        }

        public async Task Update(int id, BijouterieCommandDTO bijouterieCommand)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bijouterie), id);
            }
            else
            {
                entity.Name = bijouterieCommand.Name;
                entity.Cost = bijouterieCommand.Cost;
                entity.Amount = bijouterieCommand.Amount;
                entity.BrandId = bijouterieCommand.BrandId;
                entity.CountryId = bijouterieCommand.CountryId;
                entity.BijouterieTypeId = bijouterieCommand.BijouterieTypeId;

                _repository.Update(entity);
            }

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bijouterie), id);
            }
            else
            {
                _repository.Delete(entity);
            }

            await _repository.SaveChangesAsync();
        }
    }
}

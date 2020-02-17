using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Country;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CountryDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<CountryDto>>(entities);
        }

        public async Task<CountryDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<CountryDto>(entity);
        }

        public async Task<CountryDto> Create(CreateCountryDto createCountry)
        {
            var entity = _mapper.Map<Country>(createCountry);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CountryDto>(entity);
        }

        public async Task Update(int id, UpdateCountryDto updateCountry)
        {
            var entity = await GetEntityById(id);

            entity.Name = updateCountry.Name;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<Country> GetEntityById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), id);
            }

            return entity;
        }
    }
}

﻿using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie.Validators;
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

        public async Task<IList<GetBijouterieDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<GetBijouterieDto>>(entities);
        }

        public async Task<GetBijouterieDto> GetById(object id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Bijouterie), id);
            }

            return _mapper.Map<GetBijouterieDto>(entity);
        }

        public async Task<IList<GetBijouterieDto>> GetAllByBijouterieTypeId(int id)
        {
            var entities = await _repository.GetAllByBijouterieTypeId(id);

            return _mapper.Map<IList<GetBijouterieDto>>(entities);
        }

        public async Task<IList<GetBijouterieDto>> GetAllByBrandId(int id)
        {
            var entities = await _repository.GetAllByBrandId(id);

            return _mapper.Map<IList<GetBijouterieDto>>(entities);
        }

        public async Task<IList<GetBijouterieDto>> GetAllByCountryId(int id)
        {
            var entities = await _repository.GetAllByCountryId(id);

            return _mapper.Map<IList<GetBijouterieDto>>(entities);
        }

        public async Task Create(CreateBijouterieDto createBijouterie)
        {
            var validator = new CreateBijouterieDtoValidator();
            var result = validator.Validate(createBijouterie);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var entity = _mapper.Map<Bijouterie>(createBijouterie);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            createBijouterie.Id = entity.Id;
        }

        public async Task Update(int id, UpdateBijouterieDto updateBijouterie)
        {
            var validator = new UpdateBijouterieDtoValidator();
            var result = validator.Validate(updateBijouterie);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

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
            var validator = new RemoveBijouterieDtoValidator();
            var result = validator.Validate(removeBijouterie);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

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

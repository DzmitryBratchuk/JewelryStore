﻿using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Brand;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<BrandDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<BrandDto>>(entities);
        }

        public async Task<BrandDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<BrandDto>(entity);
        }

        public async Task<BrandDto> Create(CreateBrandDto createBrand)
        {
            var entity = _mapper.Map<Brand>(createBrand);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<BrandDto>(entity);
        }

        public async Task Update(int id, UpdateBrandDto updateBrand)
        {
            var entity = await GetEntityById(id);

            entity.Name = updateBrand.Name;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<Brand> GetEntityById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Brand), id);
            }

            return entity;
        }
    }
}

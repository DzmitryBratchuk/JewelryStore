using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Product;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<ProductDto>> GetAllByName(string name)
        {
            var entities = await _repository.GetAllByName(name);

            return _mapper.Map<IList<ProductDto>>(entities);
        }

        public async Task<IList<ProductDto>> GetAllByBrandName(string brandName)
        {
            var entities = await _repository.GetAllByBrandName(brandName);

            return _mapper.Map<IList<ProductDto>>(entities);
        }

        public async Task<IList<ProductDto>> GetAllByCountryName(string countryName)
        {
            var entities = await _repository.GetAllByCountryName(countryName);

            return _mapper.Map<IList<ProductDto>>(entities);
        }
    }
}

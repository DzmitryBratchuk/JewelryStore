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

        public async Task<IList<ProductDto>> GetAllByNameAsync(string name)
        {
            var entities = await _repository.GetAllByNameAsync(name);

            return _mapper.Map<IList<ProductDto>>(entities);
        }

        public async Task<IList<ProductDto>> GetAllByBrandNameAsync(string brandName)
        {
            var entities = await _repository.GetAllByBrandNameAsync(brandName);

            return _mapper.Map<IList<ProductDto>>(entities);
        }

        public async Task<IList<ProductDto>> GetAllByCountryNameAsync(string countryName)
        {
            var entities = await _repository.GetAllByCountryNameAsync(countryName);

            return _mapper.Map<IList<ProductDto>>(entities);
        }
    }
}

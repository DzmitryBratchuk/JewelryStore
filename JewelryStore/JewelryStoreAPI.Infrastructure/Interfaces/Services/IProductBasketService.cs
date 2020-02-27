using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IProductBasketService
    {
        Task<IList<ProductBasketDto>> GetAllProductsInBasketAsync();
        Task<ProductBasketDto> GetByIdAsync(int productId);
        Task<ProductBasketDto> AddProductInBasketAsync(AddProductInBasketDto addProductInBasket);
        Task UpdateProductInBasketAsync(UpdateProductBasketDto updateProductBasket);
        Task RemoveProductFromBasketAsync(int productId);
    }
}

using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IProductBasketService
    {
        Task<IList<ProductBasketDto>> GetAllProductsInBasket(int userId);
        Task<ProductBasketDto> GetById(int userId, int productId);
        Task<int> AddProductInBasket(int userId, AddProductInBasketDto addProductInBasket);
        Task UpdateProductInBasket(int userId, UpdateProductBasketDto updateProductBasket);
        Task RemoveProductFromBasket(int userId, RemoveProductBasketDto removeProductBasket);
    }
}

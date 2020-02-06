using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IProductBasketService
    {
        Task<IList<ProductBasketDto>> GetAllProductsInBasket();
        Task<ProductBasketDto> GetById(int productId);
        Task AddProductInBasket(AddProductInBasketDto addProductInBaske);
        Task UpdateProductInBasket(int productId, UpdateProductBasketDto updateProductBasket);
        Task RemoveProductFromBasket(RemoveProductBasketDto removeProductBasket);
    }
}

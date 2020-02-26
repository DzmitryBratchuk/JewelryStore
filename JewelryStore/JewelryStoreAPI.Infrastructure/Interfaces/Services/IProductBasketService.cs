using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IProductBasketService
    {
        Task<IList<ProductBasketDto>> GetAllProductsInBasket();
        Task<ProductBasketDto> GetById(int productId);
        Task<ProductBasketDto> AddProductInBasket(AddProductInBasketDto addProductInBasket);
        Task UpdateProductInBasket(UpdateProductBasketDto updateProductBasket);
        Task RemoveProductFromBasket(int productId);
    }
}

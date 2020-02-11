using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IProductOrderService
    {
        Task<IList<ProductOrderDto>> GetAllProductsInOrder(int userId, int orderId);
        Task<IList<OrderDto>> GetAllUserOrders(int userId);
        Task<int> CreateOrder(int userId, CreateOrderDto createOrder);
    }
}

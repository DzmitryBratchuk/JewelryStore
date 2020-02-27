using JewelryStoreAPI.Infrastructure.DTO.PreciousItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IPreciousItemService
    {
        Task<PreciousItemDto> GetByIdAsync(int id);
        Task<IList<PreciousItemDto>> GetAllAsync();
        Task<IList<PreciousItemDto>> GetAllByCountryIdAsync(int countryId);
        Task<IList<PreciousItemDto>> GetAllByBrandIdAsync(int brandId);
        Task<IList<PreciousItemDto>> GetAllByPreciousItemTypeIdAsync(int preciousItemTypeId);
        Task<PreciousItemDto> CreateAsync(CreatePreciousItemDto createPreciousItem);
        Task UpdateAsync(int id, UpdatePreciousItemDto updatePreciousItem);
        Task DeleteAsync(int id);
    }
}

using JewelryStoreAPI.Infrastructure.DTO.PreciousItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IPreciousItemService
    {
        Task<PreciousItemDto> GetById(int id);
        Task<IList<PreciousItemDto>> GetAll();
        Task<IList<PreciousItemDto>> GetAllByCountryId(int countryId);
        Task<IList<PreciousItemDto>> GetAllByBrandId(int brandId);
        Task<IList<PreciousItemDto>> GetAllByPreciousItemTypeId(int preciousItemTypeId);
        Task Create(CreatePreciousItemDto createPreciousItem);
        Task Update(int id, UpdatePreciousItemDto updatePreciousItem);
        Task Delete(RemovePreciousItemDto removePreciousItem);
    }
}

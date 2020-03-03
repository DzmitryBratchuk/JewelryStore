using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IPreciousItemTypeService
    {
        Task<PreciousItemTypeDto> GetByIdAsync(int id);
        Task<IList<PreciousItemTypeDto>> GetAllByMetalTypeAsync(MetalType metalType);
        Task<IList<PreciousItemTypeDto>> GetAllAsync();
        Task<PreciousItemTypeDto> CreateAsync(CreatePreciousItemTypeDto createPreciousItemType);
        Task UpdateAsync(int id, UpdatePreciousItemTypeDto updatePreciousItemType);
        Task DeleteAsync(int id);
    }
}

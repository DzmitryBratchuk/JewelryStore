using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IPreciousItemTypeService
    {
        Task<PreciousItemTypeDto> GetById(int id);
        Task<IList<PreciousItemTypeDto>> GetAllByMetalTypeName(string metalTypeName);
        Task<IList<PreciousItemTypeDto>> GetAll();
        Task Create(CreatePreciousItemTypeDto createPreciousItemType);
        Task Update(int id, UpdatePreciousItemTypeDto updatePreciousItemType);
        Task Delete(RemovePreciousItemTypeDto removePreciousItemType);
    }
}

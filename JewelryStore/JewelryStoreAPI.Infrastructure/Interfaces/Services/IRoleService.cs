using JewelryStoreAPI.Infrastructure.DTO.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IRoleService
    {
        Task<RoleDto> GetByIdAsync(int id);
        Task<IList<RoleDto>> GetAllAsync();
        Task<RoleDto> CreateAsync(CreateRoleDto createRole);
        Task UpdateAsync(int id, UpdateRoleDto updateRole);
        Task DeleteAsync(int id);
    }
}

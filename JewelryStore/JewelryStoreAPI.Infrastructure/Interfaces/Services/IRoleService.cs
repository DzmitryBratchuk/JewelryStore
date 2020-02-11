﻿using JewelryStoreAPI.Infrastructure.DTO.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IRoleService
    {
        Task<RoleDto> GetById(int id);
        Task<IList<RoleDto>> GetAll();
        Task<int> Create(CreateRoleDto createRole);
        Task Update(int id, UpdateRoleDto updateRole);
        Task Delete(RemoveRoleDto removeRole);
    }
}

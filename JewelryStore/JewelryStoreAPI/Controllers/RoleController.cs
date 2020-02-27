﻿using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Role;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<RoleModel>> GetAll()
        {
            var roles = await _roleService.GetAllAsync();

            return _mapper.Map<IList<RoleModel>>(roles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<RoleModel> GetById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);

            return _mapper.Map<RoleModel>(role);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateRoleModel createRole)
        {
            var createRoleDto = _mapper.Map<CreateRoleDto>(createRole);

            var roleDto = await _roleService.CreateAsync(createRoleDto);

            var roleModel = _mapper.Map<RoleModel>(roleDto);

            return CreatedAtAction(nameof(GetById), new { id = roleModel.Id }, roleModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRoleModel updateRole)
        {
            var role = _mapper.Map<UpdateRoleDto>(updateRole);

            await _roleService.UpdateAsync(id, role);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] RemoveRoleModel removeRole)
        {
            await _roleService.DeleteAsync(removeRole.Id);

            return NoContent();
        }
    }
}

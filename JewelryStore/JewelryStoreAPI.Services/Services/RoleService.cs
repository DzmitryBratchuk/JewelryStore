using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Role;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<RoleDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<RoleDto>>(entities);
        }

        public async Task<RoleDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), id);
            }

            return _mapper.Map<RoleDto>(entity);
        }

        public async Task Create(CreateRoleDto createRole)
        {
            var entity = _mapper.Map<Role>(createRole);

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            createRole.Id = entity.Id;
        }

        public async Task Update(int id, UpdateRoleDto updateRole)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), id);
            }

            entity.Name = updateRole.Name;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemoveRoleDto removeRole)
        {
            var entity = await _repository.GetById(removeRole.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), removeRole.Id);
            }

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }
    }
}

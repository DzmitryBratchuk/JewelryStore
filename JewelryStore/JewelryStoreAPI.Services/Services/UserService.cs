using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly CryptoHash _cryptoHash;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public UserService(IUserRepository repository, IMapper mapper, CryptoHash cryptoHash, ClaimsPrincipal claimsPrincipal)
        {
            _repository = repository;
            _mapper = mapper;
            _cryptoHash = cryptoHash;
            _claimsPrincipal = claimsPrincipal;
        }

        public async Task<UserDto> Authenticate(AuthenticateDto authenticate)
        {
            var entity = await _repository.GetByLogin(authenticate.Login);

            if (entity == null)
            {
                throw new NotFoundException($"Wrong login.");
            }

            var passwordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(authenticate.Password),
                    Encoding.UTF8.GetBytes(entity.PasswordSalt)));

            if (passwordHash != entity.PasswordHash)
            {
                throw new NotFoundException($"Wrong password or login.");
            }

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> GetByLogin(string login)
        {
            var entity = await _repository.GetByLogin(login);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), login);
            }

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IList<UserDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IList<UserDto>>(entities);
        }

        public async Task<IList<UserDto>> GetAllByRoleId(int roleId)
        {
            var entities = await _repository.GetAllByRoleId(roleId);

            return _mapper.Map<IList<UserDto>>(entities);
        }

        public async Task ChangePassword(ChangeUserPasswordDto changeUserPassword)
        {
            var userId = GetUserId();

            var entity = await GetEntityById(userId);

            var passwordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(changeUserPassword.OldPassword),
                    Encoding.UTF8.GetBytes(entity.PasswordSalt)));

            if (passwordHash != entity.PasswordHash)
            {
                throw new NotFoundException($"Wrong password or login.");
            }

            entity.PasswordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(changeUserPassword.NewPassword),
                    Encoding.UTF8.GetBytes(entity.PasswordSalt)));

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task ChangeRole(ChangeUserRoleDto changeUserRole)
        {
            var userId = GetUserId();

            var entity = await GetEntityById(userId);

            entity.RoleId = changeUserRole.RoleId;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task<UserDto> Create(CreateUserDto createUser)
        {
            var entity = _mapper.Map<User>(createUser);

            entity.PasswordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            entity.PasswordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(createUser.Password),
                    Encoding.UTF8.GetBytes(entity.PasswordSalt)));

            entity.Baskets.Add(new Basket());

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            var createdEntity = await GetEntityById(entity.Id);

            return _mapper.Map<UserDto>(createdEntity);
        }

        public async Task Update(UpdateUserDto updateUser)
        {
            var userId = GetUserId();

            var entity = await GetEntityById(userId);

            entity.FirstName = updateUser.FirstName;
            entity.LastName = updateUser.LastName;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetEntityById(id);

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }

        private async Task<User> GetEntityById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            return entity;
        }

        private int GetUserId()
        {
            return Convert.ToInt32(_claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }
    }
}

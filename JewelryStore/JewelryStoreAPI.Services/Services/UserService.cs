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
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly CryptoHash _cryptoHash;

        public UserService(IUserRepository repository, IMapper mapper, CryptoHash cryptoHash)
        {
            _repository = repository;
            _mapper = mapper;
            _cryptoHash = cryptoHash;
        }

        public async Task<UserDto> Authenticate(AuthenticateDto authenticate)
        {
            var entity = await _repository.GetByLogin(authenticate.Login);

            if (entity == null)
            {
                throw new NotFoundException($"Wrong login.");
            }

            var passwordHash = _cryptoHash.ComputeHash(
                Encoding.UTF8.GetBytes(authenticate.Password),
                entity.PasswordSalt);

            if (!passwordHash.SequenceEqual(entity.PasswordHash))
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

        public async Task ChangePassword(int id, ChangeUserPasswordDto changeUserPassword)
        {
            var entity = await GetEntityById(id);

            var passwordHash = _cryptoHash.ComputeHash(
                Encoding.UTF8.GetBytes(changeUserPassword.OldPassword),
                entity.PasswordSalt);

            if (!passwordHash.SequenceEqual(entity.PasswordHash))
            {
                throw new NotFoundException($"Wrong password or login.");
            }

            entity.PasswordHash = _cryptoHash.ComputeHash(
                Encoding.UTF8.GetBytes(changeUserPassword.NewPassword),
                entity.PasswordSalt);

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task ChangeRole(int id, ChangeUserRoleDto changeUserRole)
        {
            var entity = await GetEntityById(id);

            entity.RoleId = changeUserRole.RoleId;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task<int> Create(CreateUserDto createUser)
        {
            var entity = _mapper.Map<User>(createUser);

            entity.PasswordSalt = _cryptoHash.GetRandomSalt();
            entity.PasswordHash = _cryptoHash.ComputeHash(
                Encoding.UTF8.GetBytes(createUser.Password),
                entity.PasswordSalt);

            entity.Baskets.Add(new Basket());

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Update(int id, UpdateUserDto updateUser)
        {
            var entity = await GetEntityById(id);

            entity.FirstName = updateUser.FirstName;
            entity.LastName = updateUser.LastName;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemoveUserDto removeUser)
        {
            var entity = await GetEntityById(removeUser.Id);

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
    }
}

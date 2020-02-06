using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Infrastructure.Exceptions;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public UserService(IUserRepository repository, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<TokenDto> Authenticate(AuthenticateDto authenticate)
        {
            var entity = await _repository.GetByLogin(authenticate.Login);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), authenticate.Login);
            }

            if (entity.PasswordHash != authenticate.Password.GetHashCode())
            {
                throw new BadRequestException($"Wrong password for login {authenticate.Login}");
            }

            TokenDto getToken = new TokenDto()
            {
                Id = entity.Id,
                Token = GenerateToken(entity)
            };

            return getToken;
        }

        private string GenerateToken(User entity)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.Login),
                    new Claim(ClaimTypes.Role, entity.Role.Name),
                    new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Lifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

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
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            if (entity.PasswordHash != changeUserPassword.OldPassword.GetHashCode())
            {
                throw new BadRequestException($"Wrong password for login {entity.Login}");
            }

            entity.PasswordHash = changeUserPassword.NewPassword.GetHashCode();

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task ChangeRole(int id, ChangeUserRoleDto changeUserRole)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            entity.RoleId = changeUserRole.RoleId;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Create(CreateUserDto createUser)
        {
            var entity = _mapper.Map<User>(createUser);

            entity.Baskets.Add(new Basket());

            await _repository.Create(entity);
            await _repository.SaveChangesAsync();

            createUser.Id = entity.Id;
        }

        public async Task Update(int id, UpdateUserDto updateUser)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            entity.FirstName = updateUser.FirstName;
            entity.LastName = updateUser.LastName;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }

        public async Task Delete(RemoveUserDto removeUser)
        {
            var entity = await _repository.GetById(removeUser.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), removeUser.Id);
            }

            _repository.Delete(entity);

            await _repository.SaveChangesAsync();
        }
    }
}

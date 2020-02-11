using JewelryStoreAPI.Infrastructure.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> Authenticate(AuthenticateDto authenticate);
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByLogin(string login);
        Task<IList<UserDto>> GetAll();
        Task<IList<UserDto>> GetAllByRoleId(int roleId);
        Task ChangePassword(int id, ChangeUserPasswordDto changeUserPassword);
        Task ChangeRole(int id, ChangeUserRoleDto changeUserRole);
        Task<int> Create(CreateUserDto createUser);
        Task Update(int id, UpdateUserDto updateUser);
        Task Delete(RemoveUserDto removeUser);
    }
}

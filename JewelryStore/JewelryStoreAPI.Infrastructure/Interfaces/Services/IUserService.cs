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
        Task ChangePassword(ChangeUserPasswordDto changeUserPassword);
        Task ChangeRole(ChangeUserRoleDto changeUserRole);
        Task<UserDto> Create(CreateUserDto createUser);
        Task Update(UpdateUserDto updateUser);
        Task Delete(int id);
    }
}

using JewelryStoreAPI.Infrastructure.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> AuthenticateAsync(AuthenticateDto authenticate);
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> GetByLoginAsync(string login);
        Task<IList<UserDto>> GetAllAsync();
        Task<IList<UserDto>> GetAllByRoleIdAsync(int roleId);
        Task ChangePasswordAsync(ChangeUserPasswordDto changeUserPassword);
        Task ChangeRoleAsync(ChangeUserRoleDto changeUserRole);
        Task<UserDto> CreateAsync(CreateUserDto createUser);
        Task UpdateAsync(UpdateUserDto updateUser);
        Task DeleteAsync(int id);
    }
}

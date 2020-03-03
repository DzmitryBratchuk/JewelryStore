using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Exceptions;
using JewelryStoreAPI.Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.User
{
    public class UserServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly CryptoHash _cryptoHash;
        private readonly ClaimsPrincipal _claimsPrincipal;

        private readonly int _userId;
        private Entities.User _entity;
        private UpdateUserDto _updateUserDto;
        private CreateUserDto _createUserDto;
        private ChangeUserRoleDto _changeUserRoleDto;
        private ChangeUserPasswordDto _changeUserPasswordDto;
        private AuthenticateDto _authenticateDto;

        public UserServiceTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockUserRepository = new Mock<IUserRepository>();
            _cryptoHash = new CryptoHash();

            _userId = 1;

            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, _userId.ToString())
            });

            _claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            Initialization();
        }

        [Fact]
        public async Task AuthenticateAsync_ValidUser_NotEmptyResult()
        {
            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = GetPasswordHash(_authenticateDto.Password, passwordSalt);

            Entities.User entity = new Entities.User()
            {
                Id = 1,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = _authenticateDto.Login,
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetByLoginAsync(_authenticateDto.Login)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.AuthenticateAsync(_authenticateDto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AuthenticateAsync_LoginDoesNotExist_ExceptionThrown()
        {
            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByLoginAsync(_authenticateDto.Login)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.AuthenticateAsync(_authenticateDto));
        }

        [Fact]
        public async Task AuthenticateAsync_InvalidPassword_ExceptionThrown()
        {
            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = GetPasswordHash(_authenticateDto.Password, passwordSalt);

            Entities.User entity = new Entities.User()
            {
                Id = 1,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = _authenticateDto.Login,
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt()),
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetByLoginAsync(_authenticateDto.Login)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.AuthenticateAsync(_authenticateDto));
        }

        [Fact]
        public async Task GetAllAsync_NotEmptyResult()
        {
            IList<Entities.User> entities = new List<Entities.User>()
            {
                _entity
            };

            _mockUserRepository.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(entities));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetAllAsync();

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task GetByIdAsync_UserIdExist_NotEmptyResult()
        {
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetByIdAsync(_userId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_UserIdDoesNotExist_ExceptionThrown()
        {
            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.GetByIdAsync(_userId));
        }

        [Fact]
        public async Task GetByLoginAsync_LoginExist_NotEmptyResult()
        {
            string userLogin = "test@gmail.com";

            _mockUserRepository.Setup(p => p.GetByLoginAsync(userLogin)).Returns(Task.FromResult(_entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetByLoginAsync(userLogin);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByLoginAsync_LoginDoesNotExist_ExceptionThrown()
        {
            string userLogin = "test@gmail.com";

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByLoginAsync(userLogin)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.GetByLoginAsync(userLogin));
        }

        [Fact]
        public async Task GetAllByRoleIdAsync_RoleIdExist_NotEmptyResult()
        {
            int roleId = 1;

            IList<Entities.User> entities = new List<Entities.User>()
            {
                _entity
            };

            _mockUserRepository.Setup(p => p.GetAllByRoleIdAsync(roleId)).Returns(Task.FromResult(entities));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetAllByRoleIdAsync(roleId);

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task ChangePasswordAsync_ValidUserEntity_SuccessfulUpdate()
        {
            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = GetPasswordHash(_changeUserPasswordDto.OldPassword, passwordSalt);

            Entities.User entity = new Entities.User()
            {
                Id = _userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.ChangePasswordAsync(_changeUserPasswordDto);
        }

        [Fact]
        public async Task ChangePasswordAsync_LoginDoesNotExist_ExceptionThrown()
        {
            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.ChangePasswordAsync(_changeUserPasswordDto));
        }

        [Fact]
        public async Task ChangePasswordAsync_InvalidPassword_ExceptionThrown()
        {
            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = GetPasswordHash(_changeUserPasswordDto.OldPassword, passwordSalt);

            Entities.User entity = new Entities.User()
            {
                Id = _userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt()),
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.ChangePasswordAsync(_changeUserPasswordDto));
        }

        [Fact]
        public async Task ChangePasswordAsync_ValidUserEntity_OrmExceptionThrown()
        {
            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = GetPasswordHash(_changeUserPasswordDto.OldPassword, passwordSalt);

            Entities.User entity = new Entities.User()
            {
                Id = _userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<DbUpdateException>(() => userService.ChangePasswordAsync(_changeUserPasswordDto));
        }

        [Fact]
        public async Task ChangeRoleAsync_ValidUserEntity_SuccessfulUpdate()
        {
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.ChangeRoleAsync(_changeUserRoleDto);
        }

        [Fact]
        public async Task ChangeRoleAsync_UserDoesNotExist_ExceptionThrown()
        {
            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.ChangeRoleAsync(_changeUserRoleDto));
        }

        [Fact]
        public async Task ChangeRoleAsync_ValidUserEntity_OrmExceptionThrown()
        {
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<DbUpdateException>(() => userService.ChangeRoleAsync(_changeUserRoleDto));
        }

        [Fact]
        public async Task CreateAsync_ValidUserEntity_SuccessfulCreate()
        {
            _mockUserRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.CreateAsync(_createUserDto);

            Assert.Equal(_userId, result.Id);
        }

        [Fact]
        public async Task CreateAsync_ValidUserEntity_OrmExceptionThrown()
        {
            _mockUserRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<DbUpdateException>(() => userService.CreateAsync(_createUserDto));
        }

        [Fact]
        public async Task UpdateAsync_ValidUserEntity_SuccessfulUpdate()
        {
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.UpdateAsync(_updateUserDto);
        }

        [Fact]
        public async Task UpdateAsync_UserDoesNotExist_ExceptionThrown()
        {
            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.UpdateAsync(_updateUserDto));
        }

        [Fact]
        public async Task UpdateAsync_ValidUserEntity_OrmExceptionThrown()
        {
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<DbUpdateException>(() => userService.UpdateAsync(_updateUserDto));
        }

        [Fact]
        public async Task DeleteAsync_ValidUserEntity_SuccessfulDelete()
        {
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));
            _mockUserRepository.Setup(p => p.Delete(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.DeleteAsync(_userId);
        }

        [Fact]
        public async Task DeleteAsync_UserDoesNotExist_ExceptionThrown()
        {
            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.DeleteAsync(_userId));
        }

        [Fact]
        public async Task DeleteAsync_ValidUserEntity_OrmExceptionThrown()
        {
            _mockUserRepository.Setup(p => p.GetByIdAsync(_userId)).Returns(Task.FromResult(_entity));
            _mockUserRepository.Setup(p => p.Delete(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<DbUpdateException>(() => userService.DeleteAsync(_userId));
        }

        private string GetPasswordHash(string password, string passwordSalt)
        {
            return BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(password),
                    Encoding.UTF8.GetBytes(passwordSalt)));
        }

        private void Initialization()
        {
            _entity = new Entities.User
            {
                Id = _userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _updateUserDto = new UpdateUserDto
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name"
            };

            _createUserDto = new CreateUserDto
            {
                Id = _userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            _changeUserRoleDto = new ChangeUserRoleDto
            {
                RoleId = 1
            };

            _changeUserPasswordDto = new ChangeUserPasswordDto
            {
                OldPassword = "Test_password",
                NewPassword = "New_test_password",
                ConfirmNewPassword = "New_test_password"
            };

            _authenticateDto = new AuthenticateDto
            {
                Login = "test@gmail.com",
                Password = "Test_password"
            };
        }
    }
}

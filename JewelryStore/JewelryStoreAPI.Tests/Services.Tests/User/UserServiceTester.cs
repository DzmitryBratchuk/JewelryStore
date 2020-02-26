using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.Common;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Exceptions;
using JewelryStoreAPI.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.User
{
    using Entities = Domain.Entities;

    public class UserServiceTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly CryptoHash _cryptoHash;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public UserServiceTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockUserRepository = new Mock<IUserRepository>();
            _cryptoHash = new CryptoHash();

            int userId = 1;
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            });

            _claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        }

        [Fact]
        public async Task Should_not_have_error_Authenticate()
        {
            AuthenticateDto authenticateDto = new AuthenticateDto()
            {
                Login = "test@gmail.com",
                Password = "Test_password"
            };

            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(authenticateDto.Password),
                    Encoding.UTF8.GetBytes(passwordSalt)));

            Entities.User entity = new Entities.User()
            {
                Id = 1,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = authenticateDto.Login,
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetByLogin(authenticateDto.Login)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.Authenticate(authenticateDto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_have_error_Authenticate_LoginNotFound()
        {
            AuthenticateDto authenticateDto = new AuthenticateDto()
            {
                Login = "test@gmail.com",
                Password = "Test_password"
            };

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByLogin(authenticateDto.Login)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.Authenticate(authenticateDto));
        }

        [Fact]
        public async Task Should_have_error_Authenticate_PasswordNotFound()
        {
            AuthenticateDto authenticateDto = new AuthenticateDto()
            {
                Login = "test@gmail.com",
                Password = "Test_password"
            };

            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(authenticateDto.Password),
                    Encoding.UTF8.GetBytes(passwordSalt)));

            Entities.User entity = new Entities.User()
            {
                Id = 1,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = authenticateDto.Login,
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt()),
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetByLogin(authenticateDto.Login)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.Authenticate(authenticateDto));
        }

        [Fact]
        public async Task Should_not_have_error_GetAll()
        {
            IList<Entities.User> entities = new List<Entities.User>()
            {
                new Entities.User()
                {
                    Id = 1,
                    FirstName = "Test_firstName",
                    LastName = "Test_lastName",
                    Login = "test@gmail.com",
                    RoleId = 1,
                    Role = new Entities.Role { Id = 1, Name = "Test_role" }
                }
            };

            _mockUserRepository.Setup(p => p.GetAll()).Returns(Task.FromResult(entities));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetAll();

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetById()
        {
            int userId = 1;

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetById(userId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_have_error_GetById_NotFound()
        {
            int userId = 1;

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.GetById(userId));
        }

        [Fact]
        public async Task Should_not_have_error_GetByLogin()
        {
            string userLogin = "test@gmail.com";

            Entities.User entity = new Entities.User()
            {
                Id = 1,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = userLogin,
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetByLogin(userLogin)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetByLogin(userLogin);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_have_error_GetByLogin_NotFound()
        {
            string userLogin = "test@gmail.com";

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetByLogin(userLogin)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.GetByLogin(userLogin));
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByRoleId()
        {
            int roleId = 1;

            IList<Entities.User> entities = new List<Entities.User>()
            {
                new Entities.User()
                {
                    Id = 1,
                    FirstName = "Test_firstName",
                    LastName = "Test_lastName",
                    Login = "test@gmail.com",
                    RoleId = roleId,
                    Role = new Entities.Role { Id = roleId, Name = "Test_role" }
                }
            };

            _mockUserRepository.Setup(p => p.GetAllByRoleId(roleId)).Returns(Task.FromResult(entities));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.GetAllByRoleId(roleId);

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_ChangePassword()
        {
            int userId = 1;

            ChangeUserPasswordDto changeUserPasswordDto = new ChangeUserPasswordDto()
            {
                OldPassword = "Test_password",
                NewPassword = "New_test_password",
                ConfirmNewPassword = "New_test_password"
            };

            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(changeUserPasswordDto.OldPassword),
                    Encoding.UTF8.GetBytes(passwordSalt)));

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.ChangePassword(changeUserPasswordDto);
        }

        [Fact]
        public async Task Should_have_error_ChangePassword_LoginNotFound()
        {
            int userId = 1;

            ChangeUserPasswordDto changeUserPasswordDto = new ChangeUserPasswordDto()
            {
                OldPassword = "Test_password",
                NewPassword = "New_test_password",
                ConfirmNewPassword = "New_test_password"
            };

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.ChangePassword(changeUserPasswordDto));
        }

        [Fact]
        public async Task Should_have_error_ChangePassword_PasswordNotFound()
        {
            int userId = 1;

            ChangeUserPasswordDto changeUserPasswordDto = new ChangeUserPasswordDto()
            {
                OldPassword = "Test_password",
                NewPassword = "New_test_password",
                ConfirmNewPassword = "New_test_password"
            };

            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(changeUserPasswordDto.OldPassword),
                    Encoding.UTF8.GetBytes(passwordSalt)));

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt()),
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.ChangePassword(changeUserPasswordDto));
        }

        [Fact]
        public async Task Should_have_error_ChangePassword_OrmException()
        {
            int userId = 1;

            ChangeUserPasswordDto changeUserPasswordDto = new ChangeUserPasswordDto()
            {
                OldPassword = "Test_password",
                NewPassword = "New_test_password",
                ConfirmNewPassword = "New_test_password"
            };

            var passwordSalt = BitConverter.ToString(_cryptoHash.GetRandomSalt());
            var passwordHash = BitConverter.ToString(
                _cryptoHash.ComputeHash(
                    Encoding.UTF8.GetBytes(changeUserPasswordDto.OldPassword),
                    Encoding.UTF8.GetBytes(passwordSalt)));

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" },
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => userService.ChangePassword(changeUserPasswordDto));
        }

        [Fact]
        public async Task Should_not_have_error_ChangeRole()
        {
            int userId = 1;
            int roleId = 1;

            ChangeUserRoleDto changeUserRoleDto = new ChangeUserRoleDto()
            {
                RoleId = roleId
            };

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = roleId,
                Role = new Entities.Role { Id = roleId, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.ChangeRole(changeUserRoleDto);
        }

        [Fact]
        public async Task Should_have_error_ChangeRole_NotFound()
        {
            int userId = 1;
            int roleId = 1;

            ChangeUserRoleDto changeUserRoleDto = new ChangeUserRoleDto()
            {
                RoleId = roleId
            };

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.ChangeRole(changeUserRoleDto));
        }

        [Fact]
        public async Task Should_have_error_ChangeRole_OrmException()
        {
            int userId = 1;
            int roleId = 1;

            ChangeUserRoleDto changeUserRoleDto = new ChangeUserRoleDto()
            {
                RoleId = roleId
            };

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = roleId,
                Role = new Entities.Role { Id = roleId, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => userService.ChangeRole(changeUserRoleDto));
        }

        [Fact]
        public async Task Should_not_have_error_Create()
        {
            int userId = 1;

            CreateUserDto createUserDto = new CreateUserDto()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.Create(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());
            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            var result = await userService.Create(createUserDto);

            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task Should_have_error_Create_OrmException()
        {
            int userId = 1;

            CreateUserDto createUserDto = new CreateUserDto()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            _mockUserRepository.Setup(p => p.Create(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => userService.Create(createUserDto));
        }

        [Fact]
        public async Task Should_not_have_error_Update()
        {
            int userId = 1;

            UpdateUserDto updateUserDto = new UpdateUserDto()
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name"
            };

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.Update(updateUserDto);
        }

        [Fact]
        public async Task Should_have_error_Update_NotFound()
        {
            int userId = 1;

            UpdateUserDto updateUserDto = new UpdateUserDto()
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name"
            };

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.Update(updateUserDto));
        }

        [Fact]
        public async Task Should_have_error_Update_OrmException()
        {
            int userId = 1;

            UpdateUserDto updateUserDto = new UpdateUserDto()
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name"
            };

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Update(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => userService.Update(updateUserDto));
        }

        [Fact]
        public async Task Should_not_have_error_Delete()
        {
            int userId = 1;

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Delete(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync());

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await userService.Delete(userId);
        }

        [Fact]
        public async Task Should_have_error_Delete_NotFound()
        {
            int userId = 1;

            Entities.User entity = null;

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => userService.Delete(userId));
        }

        [Fact]
        public async Task Should_have_error_Delete_OrmException()
        {
            int userId = 1;

            Entities.User entity = new Entities.User()
            {
                Id = userId,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            _mockUserRepository.Setup(p => p.GetById(userId)).Returns(Task.FromResult(entity));
            _mockUserRepository.Setup(p => p.Delete(It.IsAny<Entities.User>()));
            _mockUserRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var userService = new UserService(_mockUserRepository.Object, _mapper, _cryptoHash, _claimsPrincipal);

            await Assert.ThrowsAsync<Exception>(() => userService.Delete(userId));
        }
    }
}

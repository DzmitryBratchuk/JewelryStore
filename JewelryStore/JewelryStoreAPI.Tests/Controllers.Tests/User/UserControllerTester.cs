using AutoMapper;
using JewelryStoreAPI.Common;
using JewelryStoreAPI.Controllers;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User
{
    public class UserControllerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IOptions<JwtSettings>> _jwtSettings;

        public UserControllerTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
            _mockUserService = new Mock<IUserService>();
            _jwtSettings = new Mock<IOptions<JwtSettings>>();

            _jwtSettings.Setup(p => p.Value).Returns(new JwtSettings() { Secret = "Very long secret SymmetricSecurityKey", Lifetime = 2 });
        }

        [Fact]
        public async Task Should_not_have_error_GetAll()
        {
            IList<UserDto> userDto = new List<UserDto>()
            {
                new UserDto
                {
                    Id = 1,
                    FirstName = "Test_first_name",
                    LastName = "Test_last_name",
                    Login = "test@gmail.com",
                    RoleName = "Test_role"
                }
            };

            _mockUserService.Setup(p => p.GetAll()).Returns(Task.FromResult(userDto));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.GetAll();

            Assert.Equal(userDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetById()
        {
            int userId = 1;

            var userDto = new UserDto
            {
                Id = 1,
                FirstName = "Test_first_name",
                LastName = "Test_last_name",
                Login = "test@gmail.com",
                RoleName = "Test_role"
            };

            _mockUserService.Setup(p => p.GetById(userId)).Returns(Task.FromResult(userDto));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.GetById(userId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByRoleId()
        {
            int roleId = 1;

            IList<UserDto> userDto = new List<UserDto>()
            {
                new UserDto
                {
                    Id = 1,
                    FirstName = "Test_first_name",
                    LastName = "Test_last_name",
                    Login = "test@gmail.com",
                    RoleName = "Test_role"
                }
            };

            _mockUserService.Setup(p => p.GetAllByRoleId(roleId)).Returns(Task.FromResult(userDto));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.GetAllByRoleId(roleId);

            Assert.Equal(userDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetByLogin()
        {
            var userLogin = "test@gmail.com";

            var userDto = new UserDto
            {
                Id = 1,
                FirstName = "Test_first_name",
                LastName = "Test_last_name",
                Login = "test@gmail.com",
                RoleName = "Test_role"
            };

            _mockUserService.Setup(p => p.GetByLogin(userLogin)).Returns(Task.FromResult(userDto));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.GetByLogin(userLogin);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_not_have_error_Authenticate()
        {
            int userId = 1;

            var authenticateModel = new AuthenticateModel()
            {
                Login = "test@gmail.com",
                Password = "Test_password"
            };

            var userDto = new UserDto
            {
                Id = 1,
                FirstName = "Test_first_name",
                LastName = "Test_last_name",
                Login = "test@gmail.com",
                RoleName = "Test_role"
            };

            _mockUserService.Setup(p => p.Authenticate(It.IsAny<AuthenticateDto>())).Returns(Task.FromResult(userDto));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.Authenticate(authenticateModel);

            Assert.Equal(userId, result.Id);
            Assert.NotNull(result.Token);
        }

        [Fact]
        public async Task Should_not_have_error_Create()
        {
            int userId = 1;

            var createUserModel = new CreateUserModel()
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name",
                Login = "test@gmail.com",
                RoleId = 1,
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            var userDto = new UserDto
            {
                Id = userId,
                FirstName = "Test_first_name",
                LastName = "Test_last_name",
                Login = "test@gmail.com",
                RoleName = "Test_role"
            };

            _mockUserService.Setup(p => p.Create(It.IsAny<CreateUserDto>())).Returns(Task.FromResult(userDto));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.Create(createUserModel);

            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            var createdData = result as CreatedAtActionResult;

            Assert.IsAssignableFrom<UserModel>(createdData.Value);
            var userModel = createdData.Value as UserModel;

            Assert.NotNull(userModel);
        }

        [Fact]
        public async Task Should_not_have_error_Update()
        {
            int userId = 1;

            var updateUserModel = new UpdateUserModel()
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name"
            };

            _mockUserService.Setup(p => p.Update(It.IsAny<UpdateUserDto>()));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            });

            userController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(claimsIdentity)
                }
            };

            var result = await userController.Update(updateUserModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public async Task Should_not_have_error_ChangeUserPassword()
        {
            var changeUserPasswordModel = new ChangeUserPasswordModel()
            {
                OldPassword = "Old_test_password",
                NewPassword = "New_test_password",
                ConfirmNewPassword = "New_test_password"
            };

            _mockUserService.Setup(p => p.ChangePassword(It.IsAny<ChangeUserPasswordDto>()));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.ChangePassword(changeUserPasswordModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public async Task Should_not_have_error_ChangeUserRole()
        {
            var changeUserRoleModel = new ChangeUserRoleModel()
            {
                RoleId = 1
            };

            _mockUserService.Setup(p => p.ChangeRole(It.IsAny<ChangeUserRoleDto>()));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.ChangeRole(changeUserRoleModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public async Task Should_not_have_error_Delete()
        {
            int userId = 1;

            RemoveUserModel removeUserModel = new RemoveUserModel()
            {
                Id = userId
            };

            _mockUserService.Setup(p => p.Delete(It.IsAny<int>()));

            var userController = new UserController(_mockUserService.Object, _mapper, _jwtSettings.Object);

            var result = await userController.Delete(removeUserModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }
    }
}

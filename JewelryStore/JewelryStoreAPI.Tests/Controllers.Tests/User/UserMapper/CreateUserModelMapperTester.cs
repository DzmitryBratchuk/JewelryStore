using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class CreateUserModelMapperTester
    {
        private readonly IMapper _mapper;

        public CreateUserModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_CreateUserModel_to_CreateUserDto()
        {
            var source = new CreateUserModel()
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name",
                Login = "test@gmail.com",
                RoleId = 1,
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            var destination = _mapper.Map<CreateUserDto>(source);

            Assert.Equal(source.FirstName, destination.FirstName);
            Assert.Equal(source.LastName, destination.LastName);
            Assert.Equal(source.Login, destination.Login);
            Assert.Equal(source.RoleId, destination.RoleId);
            Assert.Equal(source.Password, destination.Password);
            Assert.Equal(source.ConfirmPassword, destination.ConfirmPassword);
        }

        [Fact]
        public void Should_not_have_error_CreateUserModel_to_CreateUserDto_DefaultProperty()
        {
            var source = new CreateUserModel()
            {
                FirstName = default,
                LastName = default,
                Login = default,
                RoleId = default,
                Password = default,
                ConfirmPassword = default
            };

            var destination = _mapper.Map<CreateUserDto>(source);

            Assert.Null(destination.FirstName);
            Assert.Null(destination.LastName);
            Assert.Null(destination.Login);
            Assert.Null(destination.Password);
            Assert.Null(destination.ConfirmPassword);
            Assert.Equal(source.RoleId, destination.RoleId);
        }
    }
}

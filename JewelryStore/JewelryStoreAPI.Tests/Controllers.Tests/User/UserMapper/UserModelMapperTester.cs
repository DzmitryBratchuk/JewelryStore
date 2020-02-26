using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class UserModelMapperTester
    {
        private readonly IMapper _mapper;

        public UserModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_UserDto_to_UserModel()
        {
            var source = new UserDto()
            {
                Id = 1,
                FirstName = "Test_first_name",
                LastName = "Test_last_name",
                Login = "test@gmail.com",
                RoleName = "Test_role"
            };

            var destination = _mapper.Map<UserModel>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.FirstName, destination.FirstName);
            Assert.Equal(source.LastName, destination.LastName);
            Assert.Equal(source.Login, destination.Login);
            Assert.Equal(source.RoleName, destination.RoleName);
        }

        [Fact]
        public void Should_not_have_error_UserDto_to_UserModel_DefaultProperty()
        {
            var source = new UserDto()
            {
                Id = default,
                FirstName = default,
                LastName = default,
                Login = default,
                RoleName = default
            };

            var destination = _mapper.Map<UserModel>(source);

            Assert.Null(destination.FirstName);
            Assert.Null(destination.LastName);
            Assert.Null(destination.Login);
            Assert.Null(destination.RoleName);
            Assert.Equal(source.Id, destination.Id);
        }
    }
}

using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class UserModelMapperTests
    {
        private readonly IMapper _mapper;

        public UserModelMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_UserDto_To_UserModel()
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
    }
}

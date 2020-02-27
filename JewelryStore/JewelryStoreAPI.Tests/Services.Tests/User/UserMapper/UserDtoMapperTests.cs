using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.User.UserMapper
{
    using Entities = Domain.Entities;

    public class UserDtoMapperTests
    {
        private readonly IMapper _mapper;

        public UserDtoMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_User_To_UserDto()
        {
            var source = new Entities.User()
            {
                Id = 1,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Role = new Entities.Role { Id = 1, Name = "Test_role" }
            };

            var destination = _mapper.Map<UserDto>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.FirstName, destination.FirstName);
            Assert.Equal(source.LastName, destination.LastName);
            Assert.Equal(source.Login, destination.Login);
            Assert.Equal(source.Role.Name, destination.RoleName);
        }
    }
}

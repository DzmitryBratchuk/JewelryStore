using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.User.UserMapper
{
    using Entities = Domain.Entities;

    public class UserDtoMapperTester
    {
        private readonly IMapper _mapper;

        public UserDtoMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_User_to_UserDto()
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

        [Fact]
        public void Should_not_have_error_User_to_UserDto_DefaultProperty()
        {
            var source = new Entities.User()
            {
                Id = default,
                FirstName = default,
                LastName = default,
                Login = default,
                RoleId = default,
                Role = default
            };

            var destination = _mapper.Map<UserDto>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Null(destination.FirstName);
            Assert.Null(destination.LastName);
            Assert.Null(destination.Login);
            Assert.Null(destination.RoleName);
        }
    }
}

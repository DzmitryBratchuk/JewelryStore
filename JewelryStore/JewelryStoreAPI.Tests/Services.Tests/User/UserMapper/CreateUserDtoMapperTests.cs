using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.User;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.User.UserMapper
{
    using Entities = Domain.Entities;

    public class CreateUserDtoMapperTests
    {
        private readonly IMapper _mapper;

        public CreateUserDtoMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_CreateUserDto_To_User()
        {
            var source = new CreateUserDto()
            {
                Id = 1,
                FirstName = "Test_firstName",
                LastName = "Test_lastName",
                Login = "test@gmail.com",
                RoleId = 1,
                Password = "Test_password",
                ConfirmPassword = "Test_password"
            };

            var destination = _mapper.Map<Entities.User>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.FirstName, destination.FirstName);
            Assert.Equal(source.LastName, destination.LastName);
            Assert.Equal(source.Login, destination.Login);
            Assert.Equal(source.RoleId, destination.RoleId);
            Assert.Null(destination.PasswordHash);
            Assert.Null(destination.PasswordSalt);
        }
    }
}

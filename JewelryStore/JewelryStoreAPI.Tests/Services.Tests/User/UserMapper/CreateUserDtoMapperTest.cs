using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.User;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.User.UserMapper
{
    public class CreateUserDtoMapperTest
    {
        private readonly IMapper _mapper;

        public CreateUserDtoMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_CreateUserDtoToUser_SuccessfulMapping()
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

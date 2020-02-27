using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class CreateUserModelMapperTests
    {
        private readonly IMapper _mapper;

        public CreateUserModelMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_CreateUserModel_To_CreateUserDto()
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
    }
}

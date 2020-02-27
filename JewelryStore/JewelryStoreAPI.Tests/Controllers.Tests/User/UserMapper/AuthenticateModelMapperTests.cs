using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class AuthenticateModelMapperTests
    {
        private readonly IMapper _mapper;

        public AuthenticateModelMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_AuthenticateModel_To_AuthenticateDto()
        {
            var source = new AuthenticateModel()
            {
                Login = "test@gmail.com",
                Password = "Test_password"
            };

            var destination = _mapper.Map<AuthenticateDto>(source);

            Assert.Equal(source.Login, destination.Login);
            Assert.Equal(source.Password, destination.Password);
        }
    }
}

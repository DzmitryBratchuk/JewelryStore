using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class AuthenticateModelMapperTester
    {
        private readonly IMapper _mapper;

        public AuthenticateModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_AuthenticateModel_to_AuthenticateDto()
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

        [Fact]
        public void Should_not_have_error_AuthenticateModel_to_AuthenticateDto_DefaultProperty()
        {
            var source = new AuthenticateModel()
            {
                Login = default,
                Password = default
            };

            var destination = _mapper.Map<AuthenticateDto>(source);

            Assert.Null(destination.Login);
            Assert.Null(destination.Password);
        }
    }
}

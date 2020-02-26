using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class UpdateUserModelMapperTester
    {
        private readonly IMapper _mapper;

        public UpdateUserModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_UpdateUserModel_to_UpdateUserDto()
        {
            var source = new UpdateUserModel()
            {
                FirstName = "Test_first_name",
                LastName = "Test_last_name"
            };

            var destination = _mapper.Map<UpdateUserDto>(source);

            Assert.Equal(source.FirstName, destination.FirstName);
            Assert.Equal(source.LastName, destination.LastName);
        }

        [Fact]
        public void Should_not_have_error_UpdateUserModel_to_UpdateUserDto_DefaultProperty()
        {
            var source = new UpdateUserModel()
            {
                FirstName = default,
                LastName = default
            };

            var destination = _mapper.Map<UpdateUserDto>(source);

            Assert.Null(destination.FirstName);
            Assert.Null(destination.LastName);
        }
    }
}

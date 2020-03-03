using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class UpdateUserModelMapperTest
    {
        private readonly IMapper _mapper;

        public UpdateUserModelMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_UpdateUserModelToUpdateUserDto_SuccessfulMapping()
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
    }
}

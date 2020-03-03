using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class ChangeUserPasswordModelMapperTest
    {
        private readonly IMapper _mapper;

        public ChangeUserPasswordModelMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_ChangeUserPasswordModelToChangeUserPasswordDto_SuccessfulMapping()
        {
            var source = new ChangeUserPasswordModel()
            {
                OldPassword = "Old_test_password",
                NewPassword = "New_test_password",
                ConfirmNewPassword = "New_test_password"
            };

            var destination = _mapper.Map<ChangeUserPasswordDto>(source);

            Assert.Equal(source.OldPassword, destination.OldPassword);
            Assert.Equal(source.NewPassword, destination.NewPassword);
            Assert.Equal(source.ConfirmNewPassword, destination.ConfirmNewPassword);
        }
    }
}

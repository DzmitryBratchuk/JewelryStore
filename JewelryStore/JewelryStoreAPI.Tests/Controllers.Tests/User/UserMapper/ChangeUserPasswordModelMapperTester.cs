using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class ChangeUserPasswordModelMapperTester
    {
        private readonly IMapper _mapper;

        public ChangeUserPasswordModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_ChangeUserPasswordModel_to_ChangeUserPasswordDto()
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

        [Fact]
        public void Should_not_have_error_ChangeUserPasswordModel_to_ChangeUserPasswordDto_DefaultProperty()
        {
            var source = new ChangeUserPasswordModel()
            {
                OldPassword = default,
                NewPassword = default,
                ConfirmNewPassword = default
            };

            var destination = _mapper.Map<ChangeUserPasswordDto>(source);

            Assert.Null(destination.OldPassword);
            Assert.Null(destination.NewPassword);
            Assert.Null(destination.ConfirmNewPassword);
        }
    }
}

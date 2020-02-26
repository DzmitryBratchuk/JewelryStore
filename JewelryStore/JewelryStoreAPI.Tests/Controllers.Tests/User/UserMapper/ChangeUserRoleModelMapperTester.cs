using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class ChangeUserRoleModelMapperTester
    {
        private readonly IMapper _mapper;

        public ChangeUserRoleModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_ChangeUserRoleModel_to_ChangeUserRoleDto()
        {
            var source = new ChangeUserRoleModel()
            {
                RoleId = 1
            };

            var destination = _mapper.Map<ChangeUserRoleDto>(source);

            Assert.Equal(source.RoleId, destination.RoleId);
        }

        [Fact]
        public void Should_not_have_error_ChangeUserRoleModel_to_ChangeUserRoleDto_DefaultProperty()
        {
            var source = new ChangeUserRoleModel()
            {
                RoleId = default
            };

            var destination = _mapper.Map<ChangeUserRoleDto>(source);

            Assert.Equal(source.RoleId, destination.RoleId);
        }
    }
}

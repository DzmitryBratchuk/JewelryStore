using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Models.User;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.User.UserMapper
{
    public class ChangeUserRoleModelMapperTests
    {
        private readonly IMapper _mapper;

        public ChangeUserRoleModelMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_ChangeUserRoleModel_To_ChangeUserRoleDto()
        {
            var source = new ChangeUserRoleModel()
            {
                RoleId = 1
            };

            var destination = _mapper.Map<ChangeUserRoleDto>(source);

            Assert.Equal(source.RoleId, destination.RoleId);
        }
    }
}

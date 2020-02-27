using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.Bijouterie.BijouterieMapper
{
    using Entities = Domain.Entities;

    public class CreateBijouterieDtoMapperTests
    {
        private readonly IMapper _mapper;

        public CreateBijouterieDtoMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_CreateBijouterieDto_To_Bijouterie()
        {
            var source = new CreateBijouterieDto()
            {
                Id = 1,
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            var destination = _mapper.Map<Entities.Bijouterie>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BrandId, destination.BrandId);
            Assert.Equal(source.CountryId, destination.CountryId);
            Assert.Equal(source.BijouterieTypeId, destination.BijouterieTypeId);
        }
    }
}

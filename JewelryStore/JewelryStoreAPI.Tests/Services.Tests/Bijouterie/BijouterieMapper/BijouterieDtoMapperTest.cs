using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.Bijouterie.BijouterieMapper
{
    public class BijouterieDtoMapperTest
    {
        private readonly IMapper _mapper;

        public BijouterieDtoMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_BijouterieToBijouterieDto_SuccessfulMapping()
        {
            var source = new Entities.Bijouterie()
            {
                Id = 1,
                Name = "Test name",
                BrandId = 1,
                Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                CountryId = 1,
                Country = new Entities.Country { Id = 1, Name = "Test country" },
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1,
                BijouterieType = new Entities.BijouterieType { Id = 1, Name = "Test type" }
            };

            var destination = _mapper.Map<BijouterieDto>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.Brand.Name, destination.BrandName);
            Assert.Equal(source.Country.Name, destination.CountryName);
            Assert.Equal(source.BijouterieType.Name, destination.BijouterieTypeName);
        }
    }
}

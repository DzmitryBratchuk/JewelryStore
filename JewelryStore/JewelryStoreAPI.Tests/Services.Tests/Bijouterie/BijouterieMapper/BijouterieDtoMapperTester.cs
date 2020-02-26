using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.Bijouterie.BijouterieMapper
{
    using Entities = Domain.Entities;

    public class BijouterieDtoMapperTester
    {
        private readonly IMapper _mapper;

        public BijouterieDtoMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_Bijouterie_to_BijouterieDto()
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

        [Fact]
        public void Should_not_have_error_Bijouterie_to_BijouterieDto_DefaultProperty()
        {
            var source = new Entities.Bijouterie()
            {
                Id = default,
                Name = default,
                BrandId = default,
                Brand = default,
                CountryId = default,
                Country = default,
                Amount = default,
                Cost = default,
                BijouterieTypeId = default,
                BijouterieType = default
            };

            var destination = _mapper.Map<BijouterieDto>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Null(destination.BrandName);
            Assert.Null(destination.CountryName);
            Assert.Null(destination.BijouterieTypeName);
        }
    }
}

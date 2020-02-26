using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Models.Bijouterie;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieMapper
{
    public class BijouterieModelMapperTester
    {
        private readonly IMapper _mapper;

        public BijouterieModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_BijouterieDto_to_BijouterieModel()
        {
            var source = new BijouterieDto()
            {
                Id = 1,
                Name = "Test name",
                BrandName = "Test brand",
                CountryName = "Test country",
                Amount = 5,
                Cost = 100,
                BijouterieTypeName = "Test type"
            };

            var destination = _mapper.Map<BijouterieModel>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.BrandName, destination.BrandName);
            Assert.Equal(source.CountryName, destination.CountryName);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BijouterieTypeName, destination.BijouterieTypeName);
        }

        [Fact]
        public void Should_not_have_error_BijouterieDto_to_BijouterieModel_DefaultProperty()
        {
            var source = new BijouterieDto()
            {
                Id = default,
                Name = default,
                BrandName = default,
                CountryName = default,
                Amount = default,
                Cost = default,
                BijouterieTypeName = default
            };

            var destination = _mapper.Map<BijouterieModel>(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.BrandName, destination.BrandName);
            Assert.Equal(source.CountryName, destination.CountryName);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BijouterieTypeName, destination.BijouterieTypeName);
        }
    }
}

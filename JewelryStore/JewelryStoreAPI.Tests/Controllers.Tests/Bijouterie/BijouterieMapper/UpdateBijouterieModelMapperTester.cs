using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Models.Bijouterie;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieMapper
{
    public class UpdateBijouterieModelMapperTester
    {
        private readonly IMapper _mapper;

        public UpdateBijouterieModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_UpdateBijouterieModel_to_UpdateBijouterieDto()
        {
            var source = new UpdateBijouterieModel()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 2,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 3
            };

            var destination = _mapper.Map<UpdateBijouterieDto>(source);

            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.BrandId, destination.BrandId);
            Assert.Equal(source.CountryId, destination.CountryId);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BijouterieTypeId, destination.BijouterieTypeId);
        }

        [Fact]
        public void Should_not_have_error_UpdateBijouterieModel_to_UpdateBijouterieDto_DefaultProperty()
        {
            var source = new UpdateBijouterieModel()
            {
                Name = default,
                BrandId = default,
                CountryId = default,
                Amount = default,
                Cost = default,
                BijouterieTypeId = default
            };

            var destination = _mapper.Map<UpdateBijouterieDto>(source);

            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.BrandId, destination.BrandId);
            Assert.Equal(source.CountryId, destination.CountryId);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BijouterieTypeId, destination.BijouterieTypeId);
        }
    }
}

using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Models.Bijouterie;
using JewelryStoreAPI.Presentations;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie.BijouterieMapper
{
    public class CreateBijouterieModelMapperTester
    {
        private readonly IMapper _mapper;

        public CreateBijouterieModelMapperTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_not_have_error_CreateBijouterieModel_to_CreateBijouterieDto()
        {
            var source = new CreateBijouterieModel()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 2,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 3
            };

            var destination = _mapper.Map<CreateBijouterieDto>(source);

            Assert.Equal(default, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.BrandId, destination.BrandId);
            Assert.Equal(source.CountryId, destination.CountryId);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BijouterieTypeId, destination.BijouterieTypeId);
        }

        [Fact]
        public void Should_not_have_error_CreateBijouterieModel_to_CreateBijouterieDto_DefaultProperty()
        {
            var source = new CreateBijouterieModel()
            {
                Name = default,
                BrandId = default,
                CountryId = default,
                Amount = default,
                Cost = default,
                BijouterieTypeId = default
            };

            var destination = _mapper.Map<CreateBijouterieDto>(source);

            Assert.Equal(default, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.BrandId, destination.BrandId);
            Assert.Equal(source.CountryId, destination.CountryId);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BijouterieTypeId, destination.BijouterieTypeId);
        }
    }
}

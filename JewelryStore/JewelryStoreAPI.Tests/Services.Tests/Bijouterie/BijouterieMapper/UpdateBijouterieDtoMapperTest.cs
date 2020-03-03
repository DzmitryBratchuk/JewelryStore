using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.Bijouterie.BijouterieMapper
{
    public class UpdateBijouterieDtoMapperTest
    {
        private readonly IMapper _mapper;

        public UpdateBijouterieDtoMapperTest()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Map_UpdateBijouterieDtoToBijouterie_SuccessfulMapping()
        {
            var source = new UpdateBijouterieDto()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            var destination = _mapper.Map<Entities.Bijouterie>(source);

            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Amount, destination.Amount);
            Assert.Equal(source.Cost, destination.Cost);
            Assert.Equal(source.BrandId, destination.BrandId);
            Assert.Equal(source.CountryId, destination.CountryId);
            Assert.Equal(source.BijouterieTypeId, destination.BijouterieTypeId);
        }
    }
}

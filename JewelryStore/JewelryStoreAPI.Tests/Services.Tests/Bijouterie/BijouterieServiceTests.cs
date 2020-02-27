using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Exceptions;
using JewelryStoreAPI.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Services.Tests.Bijouterie
{
    using Entities = Domain.Entities;

    public class BijouterieServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBijouterieRepository> _mockBijouterieRepository;

        private IList<Entities.Bijouterie> _entities;
        private CreateBijouterieDto _createBijouterieDto;
        private UpdateBijouterieDto _updateBijouterieDto;

        public BijouterieServiceTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockBijouterieRepository = new Mock<IBijouterieRepository>();

            Initialization();
        }

        [Fact]
        public async Task Should_Not_Have_Error_GetAll()
        {
            _mockBijouterieRepository.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(_entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAllAsync();

            Assert.Equal(_entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_Not_Have_Error_GetById()
        {
            int bijouterieId = 1;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(_entities[0]));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetByIdAsync(bijouterieId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Have_Error_GetById_NotFound()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = null;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => bijouterieService.GetByIdAsync(bijouterieId));
        }

        [Fact]
        public async Task Should_Not_Have_Error_GetAllByBijouterieTypeId()
        {
            int bijouterieTypeId = 1;

            _mockBijouterieRepository.Setup(p => p.GetAllByBijouterieTypeIdAsync(bijouterieTypeId)).Returns(Task.FromResult(_entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAllByBijouterieTypeIdAsync(bijouterieTypeId);

            Assert.Equal(_entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_Not_Have_Error_GetAllByBrandId()
        {
            int brandId = 1;

            _mockBijouterieRepository.Setup(p => p.GetAllByBrandIdAsync(brandId)).Returns(Task.FromResult(_entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAllByBrandIdAsync(brandId);

            Assert.Equal(_entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_Not_Have_Error_GetAllByCountryId()
        {
            int countryId = 1;

            _mockBijouterieRepository.Setup(p => p.GetAllByCountryIdAsync(countryId)).Returns(Task.FromResult(_entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAllByCountryIdAsync(countryId);

            Assert.Equal(_entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_Not_Have_Error_Create()
        {
            int bijouterieId = 1;

            _mockBijouterieRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync());
            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(_entities[0]));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.CreateAsync(_createBijouterieDto);

            Assert.Equal(bijouterieId, result.Id);
        }

        [Fact]
        public async Task Should_Have_Error_Create_OrmException()
        {
            _mockBijouterieRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => bijouterieService.CreateAsync(_createBijouterieDto));
        }

        [Fact]
        public async Task Should_Not_Have_Error_Update()
        {
            int bijouterieId = 1;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(_entities[0]));
            _mockBijouterieRepository.Setup(p => p.Update(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync());

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await bijouterieService.UpdateAsync(bijouterieId, _updateBijouterieDto);
        }

        [Fact]
        public async Task Should_Have_Error_Update_NotFound()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = null;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => bijouterieService.UpdateAsync(bijouterieId, _updateBijouterieDto));
        }

        [Fact]
        public async Task Should_Have_Error_Update_OrmException()
        {
            int bijouterieId = 1;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(_entities[0]));
            _mockBijouterieRepository.Setup(p => p.Update(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => bijouterieService.UpdateAsync(bijouterieId, _updateBijouterieDto));
        }

        [Fact]
        public async Task Should_Not_Have_Error_Delete()
        {
            int bijouterieId = 1;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(_entities[0]));
            _mockBijouterieRepository.Setup(p => p.Delete(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync());

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await bijouterieService.DeleteAsync(bijouterieId);
        }

        [Fact]
        public async Task Should_Have_Error_Delete_NotFound()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = null;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => bijouterieService.DeleteAsync(bijouterieId));
        }

        [Fact]
        public async Task Should_Have_Error_Delete_OrmException()
        {
            int bijouterieId = 1;

            _mockBijouterieRepository.Setup(p => p.GetByIdAsync(bijouterieId)).Returns(Task.FromResult(_entities[0]));
            _mockBijouterieRepository.Setup(p => p.Update(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => bijouterieService.DeleteAsync(bijouterieId));
        }

        private void Initialization()
        {
            _entities = new List<Entities.Bijouterie>()
            {
                new Entities.Bijouterie()
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
                }
            };

            _createBijouterieDto = new CreateBijouterieDto()
            {
                Id = 1,
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            _updateBijouterieDto = new UpdateBijouterieDto()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };
        }
    }
}

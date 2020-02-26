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

    public class BijouterieServiceTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBijouterieRepository> _mockBijouterieRepository;

        public BijouterieServiceTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();
            _mockBijouterieRepository = new Mock<IBijouterieRepository>();
        }

        [Fact]
        public async Task Should_not_have_error_GetAll()
        {
            IList<Entities.Bijouterie> entities = new List<Entities.Bijouterie>()
            {
                new Entities.Bijouterie
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

            _mockBijouterieRepository.Setup(p => p.GetAll()).Returns(Task.FromResult(entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAll();

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetById()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = new Entities.Bijouterie()
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

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetById(bijouterieId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_have_error_GetById_NotFound()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = null;

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => bijouterieService.GetById(bijouterieId));
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByBijouterieTypeId()
        {
            int bijouterieTypeId = 1;

            IList<Entities.Bijouterie> entities = new List<Entities.Bijouterie>()
            {
                new Entities.Bijouterie
                {
                    Id = 1,
                    Name = "Test name",
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" },
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeId = bijouterieTypeId,
                    BijouterieType = new Entities.BijouterieType { Id = bijouterieTypeId, Name = "Test type" }
                }
            };

            _mockBijouterieRepository.Setup(p => p.GetAllByBijouterieTypeId(bijouterieTypeId)).Returns(Task.FromResult(entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAllByBijouterieTypeId(bijouterieTypeId);

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByBrandId()
        {
            int brandId = 1;

            IList<Entities.Bijouterie> entities = new List<Entities.Bijouterie>()
            {
                new Entities.Bijouterie
                {
                    Id = 1,
                    Name = "Test name",
                    BrandId = brandId,
                    Brand = new Entities.Brand { Id = brandId, Name = "Test brand" },
                    CountryId = 1,
                    Country = new Entities.Country { Id = 1, Name = "Test country" },
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeId = 1,
                    BijouterieType = new Entities.BijouterieType { Id = 1, Name = "Test type" }
                }
            };

            _mockBijouterieRepository.Setup(p => p.GetAllByBrandId(brandId)).Returns(Task.FromResult(entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAllByBrandId(brandId);

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByCountryId()
        {
            int countryId = 1;

            IList<Entities.Bijouterie> entities = new List<Entities.Bijouterie>()
            {
                new Entities.Bijouterie
                {
                    Id = 1,
                    Name = "Test name",
                    BrandId = 1,
                    Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                    CountryId = countryId,
                    Country = new Entities.Country { Id = countryId, Name = "Test country" },
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeId = 1,
                    BijouterieType = new Entities.BijouterieType { Id = 1, Name = "Test type" }
                }
            };

            _mockBijouterieRepository.Setup(p => p.GetAllByCountryId(countryId)).Returns(Task.FromResult(entities));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.GetAllByCountryId(countryId);

            Assert.Equal(entities.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_Create()
        {
            int bijouterieId = 1;

            CreateBijouterieDto createBijouterieDto = new CreateBijouterieDto()
            {
                Id = bijouterieId,
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            Entities.Bijouterie entity = new Entities.Bijouterie()
            {
                Id = bijouterieId,
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

            _mockBijouterieRepository.Setup(p => p.Create(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync());
            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            var result = await bijouterieService.Create(createBijouterieDto);

            Assert.Equal(bijouterieId, result.Id);
        }

        [Fact]
        public async Task Should_have_error_Create_OrmException()
        {
            int bijouterieId = 1;

            CreateBijouterieDto createBijouterieDto = new CreateBijouterieDto()
            {
                Id = bijouterieId,
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            _mockBijouterieRepository.Setup(p => p.Create(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => bijouterieService.Create(createBijouterieDto));
        }

        [Fact]
        public async Task Should_not_have_error_Update()
        {
            int bijouterieId = 1;

            UpdateBijouterieDto updateBijouterieDto = new UpdateBijouterieDto()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            Entities.Bijouterie entity = new Entities.Bijouterie()
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

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));
            _mockBijouterieRepository.Setup(p => p.Update(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync());

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await bijouterieService.Update(bijouterieId, updateBijouterieDto);
        }

        [Fact]
        public async Task Should_have_error_Update_NotFound()
        {
            int bijouterieId = 1;

            UpdateBijouterieDto updateBijouterieDto = new UpdateBijouterieDto()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            Entities.Bijouterie entity = null;

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => bijouterieService.Update(bijouterieId, updateBijouterieDto));
        }

        [Fact]
        public async Task Should_have_error_Update_OrmException()
        {
            int bijouterieId = 1;

            UpdateBijouterieDto updateBijouterieDto = new UpdateBijouterieDto()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            Entities.Bijouterie entity = new Entities.Bijouterie()
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

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));
            _mockBijouterieRepository.Setup(p => p.Update(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => bijouterieService.Update(bijouterieId, updateBijouterieDto));
        }

        [Fact]
        public async Task Should_not_have_error_Delete()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = new Entities.Bijouterie()
            {
                Id = bijouterieId,
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

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));
            _mockBijouterieRepository.Setup(p => p.Delete(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync());

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await bijouterieService.Delete(bijouterieId);
        }

        [Fact]
        public async Task Should_have_error_Delete_NotFound()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = null;

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => bijouterieService.Delete(bijouterieId));
        }

        [Fact]
        public async Task Should_have_error_Delete_OrmException()
        {
            int bijouterieId = 1;

            Entities.Bijouterie entity = new Entities.Bijouterie()
            {
                Id = bijouterieId,
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

            _mockBijouterieRepository.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(entity));
            _mockBijouterieRepository.Setup(p => p.Update(It.IsAny<Entities.Bijouterie>()));
            _mockBijouterieRepository.Setup(p => p.SaveChangesAsync()).Throws<Exception>();

            var bijouterieService = new BijouterieService(_mockBijouterieRepository.Object, _mapper);

            await Assert.ThrowsAsync<Exception>(() => bijouterieService.Delete(bijouterieId));
        }
    }
}

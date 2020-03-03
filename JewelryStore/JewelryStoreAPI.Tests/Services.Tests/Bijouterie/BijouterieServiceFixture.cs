using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.Bijouterie
{
    public class BijouterieServiceFixture : IDisposable
    {
        private readonly IMapper _mapper;

        public readonly Mock<IBijouterieRepository> MockBijouterieRepository;

        public readonly BijouterieService BijouterieService;

        public readonly int BijouterieId;
        public readonly int CountryId;
        public readonly int BrandId;
        public readonly int BijouterieTypeId;
        public readonly int IdDoesNotExist;

        public readonly IList<Entities.Bijouterie> Entities;
        public readonly CreateBijouterieDto CreateBijouterieDto;
        public readonly UpdateBijouterieDto UpdateBijouterieDto;

        public BijouterieServiceFixture()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();

            MockBijouterieRepository = new Mock<IBijouterieRepository>();

            BijouterieId = 1;
            CountryId = 1;
            BrandId = 1;
            BijouterieTypeId = 1;
            IdDoesNotExist = 2;

            Entities = new List<Entities.Bijouterie>
            {
                new Entities.Bijouterie
                {
                    Id = BijouterieId,
                    Name = "Test name",
                    BrandId = BrandId,
                    Brand = new Entities.Brand { Id = BrandId, Name = "Test brand" },
                    CountryId = CountryId,
                    Country = new Entities.Country { Id = CountryId, Name = "Test country" },
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeId = BijouterieTypeId,
                    BijouterieType = new Entities.BijouterieType { Id = BijouterieTypeId, Name = "Test type" }
                }
            };

            CreateBijouterieDto = new CreateBijouterieDto
            {
                Id = BijouterieId,
                Name = "Test name",
                BrandId = BrandId,
                CountryId = CountryId,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = BijouterieTypeId
            };

            UpdateBijouterieDto = new UpdateBijouterieDto
            {
                Name = "Test name",
                BrandId = BrandId,
                CountryId = CountryId,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = BijouterieTypeId
            };

            Entities.Bijouterie entity = null;

            MockBijouterieRepository.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(Entities));

            MockBijouterieRepository.Setup(p => p.GetByIdAsync(BijouterieId)).Returns(Task.FromResult(Entities[0]));

            MockBijouterieRepository.Setup(p => p.GetByIdAsync(IdDoesNotExist)).Returns(Task.FromResult(entity));

            MockBijouterieRepository.Setup(p => p.GetAllByBijouterieTypeIdAsync(BijouterieTypeId)).Returns(Task.FromResult(Entities));

            MockBijouterieRepository.Setup(p => p.GetAllByBrandIdAsync(BrandId)).Returns(Task.FromResult(Entities));

            MockBijouterieRepository.Setup(p => p.GetAllByCountryIdAsync(CountryId)).Returns(Task.FromResult(Entities));

            MockBijouterieRepository.Setup(p => p.CreateAsync(It.IsAny<Entities.Bijouterie>()));

            MockBijouterieRepository.Setup(p => p.SaveChangesAsync());

            MockBijouterieRepository.Setup(p => p.Update(It.IsAny<Entities.Bijouterie>()));

            MockBijouterieRepository.Setup(p => p.Delete(It.IsAny<Entities.Bijouterie>()));

            BijouterieService = new BijouterieService(MockBijouterieRepository.Object, _mapper);
        }

        public void SetupOrmDbUpdateException()
        {
            MockBijouterieRepository.Setup(p => p.SaveChangesAsync()).Throws<DbUpdateException>();
        }

        public void ResetOrmDbUpdateException()
        {
            MockBijouterieRepository.Setup(p => p.SaveChangesAsync());
        }

        public void Dispose()
        {

        }
    }
}

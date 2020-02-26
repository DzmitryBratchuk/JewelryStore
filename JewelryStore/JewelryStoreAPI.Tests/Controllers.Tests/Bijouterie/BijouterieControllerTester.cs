using AutoMapper;
using JewelryStoreAPI.Controllers;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Bijouterie;
using JewelryStoreAPI.Presentations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Bijouterie
{
    public class BijouterieControllerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBijouterieService> _mockBijouterieService;

        public BijouterieControllerTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
            _mockBijouterieService = new Mock<IBijouterieService>();
        }

        [Fact]
        public async Task Should_not_have_error_GetAll()
        {
            IList<BijouterieDto> bijouterieDto = new List<BijouterieDto>()
            {
                new BijouterieDto
                {
                    Id = 1,
                    Name = "Test name",
                    BrandName = "Test brand",
                    CountryName = "Test country",
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeName = "Test type"
                }
            };

            _mockBijouterieService.Setup(p => p.GetAll()).Returns(Task.FromResult(bijouterieDto));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.GetAll();

            Assert.Equal(bijouterieDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetById()
        {
            int bijouterieId = 1;

            var bijouterieDto = new BijouterieDto()
            {
                Id = bijouterieId,
                Name = "Test name",
                BrandName = "Test brand",
                CountryName = "Test country",
                Amount = 5,
                Cost = 100,
                BijouterieTypeName = "Test type"
            };

            _mockBijouterieService.Setup(p => p.GetById(bijouterieId)).Returns(Task.FromResult(bijouterieDto));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.GetById(bijouterieId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByBijouterieTypeId()
        {
            int bijouterieTypeId = 1;

            IList<BijouterieDto> bijouterieDto = new List<BijouterieDto>()
            {
                new BijouterieDto
                {
                    Id = 1,
                    Name = "Test name",
                    BrandName = "Test brand",
                    CountryName = "Test country",
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeName = "Test type"
                }
            };

            _mockBijouterieService.Setup(p => p.GetAllByBijouterieTypeId(bijouterieTypeId)).Returns(Task.FromResult(bijouterieDto));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.GetAllByBijouterieTypeId(bijouterieTypeId);

            Assert.Equal(bijouterieDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByBrandId()
        {
            int brandId = 1;

            IList<BijouterieDto> bijouterieDto = new List<BijouterieDto>()
            {
                new BijouterieDto
                {
                    Id = 1,
                    Name = "Test name",
                    BrandName = "Test brand",
                    CountryName = "Test country",
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeName = "Test type"
                }
            };

            _mockBijouterieService.Setup(p => p.GetAllByBrandId(brandId)).Returns(Task.FromResult(bijouterieDto));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.GetAllByBrandId(brandId);

            Assert.Equal(bijouterieDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetAllByCountryId()
        {
            int countryId = 1;

            IList<BijouterieDto> bijouterieDto = new List<BijouterieDto>()
            {
                new BijouterieDto
                {
                    Id = 1,
                    Name = "Test name",
                    BrandName = "Test brand",
                    CountryName = "Test country",
                    Amount = 5,
                    Cost = 100,
                    BijouterieTypeName = "Test type"
                }
            };

            _mockBijouterieService.Setup(p => p.GetAllByCountryId(countryId)).Returns(Task.FromResult(bijouterieDto));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.GetAllByCountryId(countryId);

            Assert.Equal(bijouterieDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_Post()
        {
            int bijouterieId = 1;

            CreateBijouterieModel createBijouterieModel = new CreateBijouterieModel()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            BijouterieDto bijouterieDto = new BijouterieDto()
            {
                Id = bijouterieId,
                Name = "Test name",
                BrandName = "Test brand",
                CountryName = "Test country",
                Amount = 5,
                Cost = 100,
                BijouterieTypeName = "Test type"
            };

            _mockBijouterieService.Setup(p => p.Create(It.IsAny<CreateBijouterieDto>())).Returns(Task.FromResult(bijouterieDto));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.Post(createBijouterieModel);

            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            var createdData = result as CreatedAtActionResult;

            Assert.IsAssignableFrom<BijouterieModel>(createdData.Value);
            var bijouterieModel = createdData.Value as BijouterieModel;

            Assert.NotNull(bijouterieModel);
        }

        [Fact]
        public async Task Should_not_have_error_Put()
        {
            int bijouterieId = 1;

            UpdateBijouterieModel updateBijouterieModel = new UpdateBijouterieModel()
            {
                Name = "Test name",
                BrandId = 1,
                CountryId = 1,
                Amount = 5,
                Cost = 100,
                BijouterieTypeId = 1
            };

            _mockBijouterieService.Setup(p => p.Update(bijouterieId, It.IsAny<UpdateBijouterieDto>()));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.Put(bijouterieId, updateBijouterieModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public async Task Should_not_have_error_Delete()
        {
            int bijouterieId = 1;

            RemoveBijouterieModel removeBijouterieModel = new RemoveBijouterieModel()
            {
                Id = bijouterieId
            };

            _mockBijouterieService.Setup(p => p.Delete(It.IsAny<int>()));

            var bijouterieController = new BijouterieController(_mockBijouterieService.Object, _mapper);

            var result = await bijouterieController.Delete(removeBijouterieModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }
    }
}

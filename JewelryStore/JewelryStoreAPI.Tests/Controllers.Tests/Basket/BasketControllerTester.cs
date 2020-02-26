using AutoMapper;
using JewelryStoreAPI.Controllers;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.ProductBasket;
using JewelryStoreAPI.Presentations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Basket
{
    public class BasketControllerTester
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductBasketService> _mockProductBasketService;

        public BasketControllerTester()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
            _mockProductBasketService = new Mock<IProductBasketService>();
        }

        [Fact]
        public async Task Should_not_have_error_GetAllProductsInBasket()
        {
            IList<ProductBasketDto> productBasketDto = new List<ProductBasketDto>()
            {
                new ProductBasketDto
                {
                    ProductId = 1,
                    ProductName = "Test Name",
                    ProductCost = 1,
                    ProductCountInBasket = 1,
                    ProductCountInStore = 1
                }
            };

            _mockProductBasketService.Setup(p => p.GetAllProductsInBasket()).Returns(Task.FromResult(productBasketDto));

            var basketController = new BasketController(_mockProductBasketService.Object, _mapper);

            var result = await basketController.GetAllProductsInBasket();

            Assert.Equal(productBasketDto.Count, result.Count);
        }

        [Fact]
        public async Task Should_not_have_error_GetById()
        {
            int productId = 1;

            var productBasketDto = new ProductBasketDto
            {
                ProductId = productId,
                ProductName = "Test Name",
                ProductCost = 1,
                ProductCountInBasket = 1,
                ProductCountInStore = 1
            };

            _mockProductBasketService.Setup(p => p.GetById(productId)).Returns(Task.FromResult(productBasketDto));

            var basketController = new BasketController(_mockProductBasketService.Object, _mapper);

            var result = await basketController.GetById(productId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_not_have_error_AddProductInBasket()
        {
            int productId = 1;

            var addProductInBasketModel = new AddProductInBasketModel
            {
                ProductId = productId,
                ProductCount = 1
            };

            ProductBasketDto productBasketDto = new ProductBasketDto()
            {
                ProductId = productId,
                ProductName = "Test Name",
                ProductCost = 1,
                ProductCountInBasket = 1,
                ProductCountInStore = 1
            };

            _mockProductBasketService.Setup(p => p.AddProductInBasket(It.IsAny<AddProductInBasketDto>())).Returns(Task.FromResult(productBasketDto));

            var basketController = new BasketController(_mockProductBasketService.Object, _mapper);

            var result = await basketController.AddProductInBasket(addProductInBasketModel);

            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            var createdData = result as CreatedAtActionResult;

            Assert.IsAssignableFrom<ProductBasketModel>(createdData.Value);
            var productBasketModel = createdData.Value as ProductBasketModel;

            Assert.NotNull(productBasketModel);
        }

        [Fact]
        public async Task Should_not_have_error_Put()
        {
            int productId = 1;

            var updateProductBasketModel = new UpdateProductBasketModel
            {
                ProductCount = 1
            };

            _mockProductBasketService.Setup(p => p.UpdateProductInBasket(It.IsAny<UpdateProductBasketDto>()));

            var basketController = new BasketController(_mockProductBasketService.Object, _mapper);

            var result = await basketController.Put(productId, updateProductBasketModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public async Task Should_not_have_error_Delete()
        {
            int productId = 1;

            var removeProductBasketModel = new RemoveProductBasketModel()
            {
                Id = productId
            };

            _mockProductBasketService.Setup(p => p.RemoveProductFromBasket(It.IsAny<int>()));

            var basketController = new BasketController(_mockProductBasketService.Object, _mapper);

            var result = await basketController.Delete(removeProductBasketModel);

            Assert.IsAssignableFrom<NoContentResult>(result);
        }
    }
}

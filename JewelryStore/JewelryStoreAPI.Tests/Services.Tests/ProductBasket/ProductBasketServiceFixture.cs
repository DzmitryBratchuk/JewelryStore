using AutoMapper;
using JewelryStoreAPI.Infrastructure;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.ProductBasket
{
    public class ProductBasketServiceFixture : IDisposable
    {
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public readonly Mock<IProductBasketRepository> MockProductBasketRepository;
        public readonly Mock<IBasketRepository> MockBasketRepository;

        public readonly ProductBasketService ProductBasketService;

        public readonly int UserId;
        public readonly int ProductId;
        public readonly int BasketId;
        public readonly int IdDoesNotExist;

        public readonly IList<Entities.ProductBasket> ProductBaskets;
        public readonly Entities.Basket Basket;
        public readonly AddProductInBasketDto AddProductInBasketDto;
        public readonly UpdateProductBasketDto UpdateProductBasketDto;

        public ProductBasketServiceFixture()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new InfrastructureAutoMapping())).CreateMapper();

            MockProductBasketRepository = new Mock<IProductBasketRepository>();
            MockBasketRepository = new Mock<IBasketRepository>();

            UserId = 1;
            ProductId = 1;
            BasketId = 1;
            IdDoesNotExist = 2;

            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, UserId.ToString())
            });

            _claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            ProductBaskets = new List<Entities.ProductBasket>
            {
                new Entities.ProductBasket
                {
                    ProductId = ProductId,
                    BasketId = BasketId,
                    ProductCount = 1,
                    Product = new Entities.Product
                    {
                        Id = ProductId,
                        Name = "Test name",
                        Cost = 1,
                        BrandId = 1,
                        Brand = new Entities.Brand { Id = 1, Name = "Test brand" },
                        CountryId = 1,
                        Country = new Entities.Country { Id = 1, Name = "Test country" }
                    }
                }
            };

            Basket = new Entities.Basket
            {
                Id = BasketId,
                UserId = UserId,
            };

            AddProductInBasketDto = new AddProductInBasketDto
            {
                ProductId = ProductId,
                ProductCount = 1
            };

            UpdateProductBasketDto = new UpdateProductBasketDto
            {
                ProductId = ProductId,
                ProductCount = 1
            };

            ProductBasketService = new ProductBasketService(MockProductBasketRepository.Object, MockBasketRepository.Object, _mapper, _claimsPrincipal);
        }

        public void Dispose()
        {

        }
    }
}

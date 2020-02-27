using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Models.Order;
using JewelryStoreAPI.Presentations;
using System.Collections.Generic;
using Xunit;

namespace JewelryStoreAPI.Tests.Controllers.Tests.Order.OrderMapper
{
    public class CreateOrderModelMapperTests
    {
        private readonly IMapper _mapper;

        public CreateOrderModelMapperTests()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PresentationAutoMapping())).CreateMapper();
        }

        [Fact]
        public void Should_Not_Have_Error_CreateOrderModel_To_CreateOrderDto()
        {
            var source = new CreateOrderModel()
            {
                ProductIds = new List<int>() { 1, 2, 3 }
            };

            var destination = _mapper.Map<CreateOrderDto>(source);

            Assert.Equal(default, destination.Id);
            Assert.Equal(source.ProductIds.Count, destination.ProductIds.Count);
        }
    }
}

﻿using AutoMapper;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("GetAllByName/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<ProductModel>> GetAllByName(string name)
        {
            var products = await _productService.GetAllByName(name);

            return _mapper.Map<IList<ProductModel>>(products);
        }

        [HttpGet("GetAllByBrandName/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<ProductModel>> GetAllByBrandName(string name)
        {
            var products = await _productService.GetAllByBrandName(name);

            return _mapper.Map<IList<ProductModel>>(products);
        }

        [HttpGet("GetAllByCountryName/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<ProductModel>> GetAllByCountryName(string name)
        {
            var products = await _productService.GetAllByCountryName(name);

            return _mapper.Map<IList<ProductModel>>(products);
        }
    }
}

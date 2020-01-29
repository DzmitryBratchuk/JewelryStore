﻿using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class ProductBasketConfiguration : IEntityTypeConfiguration<ProductBasket>
    {
        public void Configure(EntityTypeBuilder<ProductBasket> builder)
        {
            builder.HasKey(u => new { u.ProductId, u.BasketId });
        }
    }
}

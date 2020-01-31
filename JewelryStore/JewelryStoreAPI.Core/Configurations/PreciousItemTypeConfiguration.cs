using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class PreciousItemTypeConfiguration : IEntityTypeConfiguration<PreciousItemType>
    {
        public void Configure(EntityTypeBuilder<PreciousItemType> builder)
        {
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}

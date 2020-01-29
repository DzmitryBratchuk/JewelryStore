using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class PreciousMetalMaterialTypeConfiguration : IEntityTypeConfiguration<PreciousMetalMaterialType>
    {
        public void Configure(EntityTypeBuilder<PreciousMetalMaterialType> builder)
        {
            builder.HasIndex(x => x.PreciousMetalMaterialTypeName)
                .IsUnique();

            builder.Property(x => x.PreciousMetalMaterialTypeName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

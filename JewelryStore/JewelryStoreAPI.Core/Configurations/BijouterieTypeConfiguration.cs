using JewelryStoreAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class BijouterieTypeConfiguration : IEntityTypeConfiguration<BijouterieType>
    {
        public void Configure(EntityTypeBuilder<BijouterieType> builder)
        {
            builder.HasIndex(x => x.BijouterieTypeName)
                .IsUnique();

            builder.Property(x => x.BijouterieTypeName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}

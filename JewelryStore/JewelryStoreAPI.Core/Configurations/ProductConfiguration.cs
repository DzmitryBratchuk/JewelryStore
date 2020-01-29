using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasDiscriminator<int>("JewelryType")
                .HasValue<Product>(0)
                .HasValue<Bijouterie>(1)
                .HasValue<PreciousMetalMaterial>(2)
                .HasValue<Watch>(3);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasOne(d => d.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Products_To_Brands")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Products_To_Countries")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class PreciousItemConfiguration : IEntityTypeConfiguration<PreciousItem>
    {
        public void Configure(EntityTypeBuilder<PreciousItem> builder)
        {
            builder.HasOne(d => d.PreciousItemType)
                .WithMany(p => p.PreciousItems)
                .HasForeignKey(d => d.PreciousItemTypeId)
                .HasConstraintName("FK_PreciousItems_To_PreciousItemTypes")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

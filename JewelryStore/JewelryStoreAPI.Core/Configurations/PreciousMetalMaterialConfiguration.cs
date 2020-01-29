using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class PreciousMetalMaterialConfiguration : IEntityTypeConfiguration<PreciousMetalMaterial>
    {
        public void Configure(EntityTypeBuilder<PreciousMetalMaterial> builder)
        {
            builder.HasOne(d => d.MetalType)
                .WithMany(p => p.PreciousMetalMaterials)
                .HasForeignKey(d => d.MetalTypeId)
                .HasConstraintName("FK_PreciousMetalMaterials_To_MetalTypeTypes")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(d => d.PreciousMetalMaterialType)
                .WithMany(p => p.PreciousMetalMaterials)
                .HasForeignKey(d => d.PreciousMetalMaterialTypeId)
                .HasConstraintName("FK_PreciousMetalMaterials_To_PreciousMetalMaterialTypes")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

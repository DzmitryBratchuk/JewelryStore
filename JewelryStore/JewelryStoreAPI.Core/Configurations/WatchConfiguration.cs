using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class WatchConfiguration : IEntityTypeConfiguration<Watch>
    {
        public void Configure(EntityTypeBuilder<Watch> builder)
        {
            builder.HasOne(d => d.CaseColor)
                .WithMany(p => p.WatchesWithCaseColors)
                .HasForeignKey(d => d.CaseColorId)
                .HasConstraintName("FK_WatchesWithCaseColors_To_CaseColors")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.DialColor)
                .WithMany(p => p.WatchesWithDialColors)
                .HasForeignKey(d => d.DialColorId)
                .HasConstraintName("FK_WatchesWithDialColors_To_DialColors")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.StrapColor)
                .WithMany(p => p.WatchesWithStrapColors)
                .HasForeignKey(d => d.StrapColorId)
                .HasConstraintName("FK_WatchesWithStrapColors_To_StrapColors")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

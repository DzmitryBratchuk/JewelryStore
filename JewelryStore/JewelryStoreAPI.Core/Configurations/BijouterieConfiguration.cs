using JewelryStoreAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Configurations
{
    public class BijouterieConfiguration : IEntityTypeConfiguration<Bijouterie>
    {
        public void Configure(EntityTypeBuilder<Bijouterie> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasOne(d => d.BijouterieType)
                .WithMany(p => p.Bijouteries)
                .HasForeignKey(d => d.BijouterieTypeId)
                .HasConstraintName("FK_Bijouteries_To_BijouterieTypes")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

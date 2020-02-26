using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class PreciousItemTypeConfiguration : IEntityTypeConfiguration<PreciousItemType>
    {
        public void Configure(EntityTypeBuilder<PreciousItemType> builder)
        {
            builder.HasIndex(x => new { x.Name, x.MetalType })
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.MetalType)
                .IsRequired();
        }
    }
}

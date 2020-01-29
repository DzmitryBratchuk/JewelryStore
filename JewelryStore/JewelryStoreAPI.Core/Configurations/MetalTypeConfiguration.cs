using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class MetalTypeConfiguration : IEntityTypeConfiguration<MetalType>
    {
        public void Configure(EntityTypeBuilder<MetalType> builder)
        {
            builder.HasIndex(x => x.MetalTypeName)
                .IsUnique();

            builder.Property(x => x.MetalTypeName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

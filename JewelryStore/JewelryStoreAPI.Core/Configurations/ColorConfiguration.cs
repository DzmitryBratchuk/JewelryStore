using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasIndex(x => x.ColorName)
                .IsUnique();

            builder.Property(x => x.ColorName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

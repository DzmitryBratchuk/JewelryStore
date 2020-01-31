using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class BijouterieTypeConfiguration : IEntityTypeConfiguration<BijouterieType>
    {
        public void Configure(EntityTypeBuilder<BijouterieType> builder)
        {
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}

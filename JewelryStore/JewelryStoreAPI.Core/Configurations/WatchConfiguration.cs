using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class WatchConfiguration : IEntityTypeConfiguration<Watch>
    {
        public void Configure(EntityTypeBuilder<Watch> builder)
        {
        }
    }
}

using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasOne(d => d.User)
                .WithMany(p => p.Baskets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Baskets_To_Users")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

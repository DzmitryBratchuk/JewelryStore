using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(d => d.Basket)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.BasketId)
                .HasConstraintName("FK_Orders_To_Baskets")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

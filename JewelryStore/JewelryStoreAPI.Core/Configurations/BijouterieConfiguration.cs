using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStoreAPI.Core.Configurations
{
    public class BijouterieConfiguration : IEntityTypeConfiguration<Bijouterie>
    {
        public void Configure(EntityTypeBuilder<Bijouterie> builder)
        {
            builder.HasOne(d => d.BijouterieType)
                .WithMany(p => p.Bijouteries)
                .HasForeignKey(d => d.BijouterieTypeId)
                .HasConstraintName("FK_Bijouteries_To_BijouterieTypes")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

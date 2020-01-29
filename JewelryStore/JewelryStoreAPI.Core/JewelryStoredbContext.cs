using JewelryStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JewelryStoreAPI.Core
{
    public class JewelryStoredbContext : DbContext
    {
        public JewelryStoredbContext(DbContextOptions<JewelryStoredbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Bijouterie> Bijouteries { get; set; }
        public virtual DbSet<BijouterieType> BijouterieTypes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<MetalType> MetalTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PreciousMetalMaterial> PreciousMetalMaterials { get; set; }
        public virtual DbSet<PreciousMetalMaterialType> PreciousMetalMaterialTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBasket> ProductBaskets { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Watch> Watches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JewelryStoredbContext).Assembly);
        }
    }
}

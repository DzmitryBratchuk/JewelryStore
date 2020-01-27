using JewelryStoreAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core
{
    public class JewelryStoredbContext : DbContext
    {
        public JewelryStoredbContext(DbContextOptions<JewelryStoredbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Bijouterie> Bijouteries { get; set; }
        public virtual DbSet<PreciousMetalStuff> PreciousMetalStuffs { get; set; }
        public virtual DbSet<Wristwatch> Wristwatchs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<ProductBasket> ProductBaskets { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JewelryStoredbContext).Assembly);
            modelBuilder.Entity<ProductBasket>().HasKey(u => new { u.ProductId, u.BasketId });
        }
    }
}

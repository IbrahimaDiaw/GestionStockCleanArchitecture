using GestionStock.Domain.Entities;
using GestionStock.Domain.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure
{
    public class GestionStockDbContext : DbContext
    {
        public GestionStockDbContext(DbContextOptions<GestionStockDbContext> options) : base(options) { }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}

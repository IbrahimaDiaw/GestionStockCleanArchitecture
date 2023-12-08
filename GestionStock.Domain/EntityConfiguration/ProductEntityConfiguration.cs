using GestionStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.EntityConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {

        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(p => p.Name)
                 .IsRequired();
            builder.HasOne<BrandEntity>()
                .WithMany()
                .HasForeignKey(p => p.BrandId);
            builder.HasOne<CategoryEntity>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}

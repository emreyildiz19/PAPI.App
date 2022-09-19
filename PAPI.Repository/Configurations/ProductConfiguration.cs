using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).UseIdentityColumn();
            builder.Property(x=> x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x=> x.Title).HasMaxLength(256).IsRequired();
            builder.Property(x => x.ParentCategoryId);
            builder.Property(x => x.ChildCategoryId);
            builder.Property(x=>x.IsActive).IsRequired().HasDefaultValue(1);
            builder.ToTable("Products");

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandId);

                
        }
    }
}

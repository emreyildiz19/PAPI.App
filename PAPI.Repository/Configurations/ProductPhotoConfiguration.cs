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
    internal class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Url).IsRequired().HasMaxLength(250);
            builder.Property(x=> x.Title).IsRequired().HasMaxLength(256);
            builder.Property(x=>x.IsActive).IsRequired().HasDefaultValue(1);

            builder.ToTable("ProductPhotos");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPhotos)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Repository.Seeds
{
    internal class ProductPhotoSeed : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.HasData(new ProductPhoto
            {
                Id =1,
                ProductId = 1,
                Url = "emre",
                Title = "ürün görseli",
                IsActive = 1


            });
        }
    }
}

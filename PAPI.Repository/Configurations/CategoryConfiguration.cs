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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();
            builder.Property(x =>x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ParentId);
            builder.Property(x=> x.Code).IsRequired();
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(1);

            builder.ToTable("Categories");
        }
    }
}

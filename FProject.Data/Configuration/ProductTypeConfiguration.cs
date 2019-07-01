//using System;
using System.Collections.Generic;
using System.Text;
using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FProject.Data.Configuration
{
    public class ProductTypeConfiguration : BaseConfiguration<ProductType>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");

            builder.HasOne(x => x.Category);
        }
    }
}

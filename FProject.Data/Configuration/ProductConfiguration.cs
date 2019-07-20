using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
        }
    }
}

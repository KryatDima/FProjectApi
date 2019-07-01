using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    public class BrandConfiguration : BaseConfiguration<Brand>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");
        }
    }
}

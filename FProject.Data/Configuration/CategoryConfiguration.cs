using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
        }
    }
}

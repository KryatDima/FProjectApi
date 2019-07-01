using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    public class OrderConfiguration : BaseConfiguration<Order>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasOne(x => x.User);
        }
    }
}

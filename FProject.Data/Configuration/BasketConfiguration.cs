using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    public class BasketConfiguration : BaseConfiguration<Basket>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Basket");

            builder.HasOne(x => x.User);
        }
    }
}

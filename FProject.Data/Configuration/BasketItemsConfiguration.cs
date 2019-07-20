using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    public class BasketItemsConfiguration : BaseConfiguration<BasketItems>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<BasketItems> builder)
        {
            builder.ToTable("BasketItems");
        }
        //public void Configure(EntityTypeBuilder<BasketItems> builder)
        //{
        //    builder.ToTable("BasketItems");

        //    //builder.HasKey(x => new {x.Id/* x.BasketId, x.ProductId*//*, x.Quantity*/ });

        //    //builder.HasOne(x => x.Basket)
        //    //    .WithMany(x => x.BasketItems)
        //    //    .HasForeignKey(x => x.BasketId);

        //    //builder.HasOne(x => x.Product)
        //    //    .WithMany(x => x.BasketItems)
        //    //    .HasForeignKey(x => x.ProductId);
        //}
    }
}

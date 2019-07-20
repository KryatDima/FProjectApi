using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Configuration
{
    class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public  void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(x => new { x.OrderId, x.ProductId, x.Quantity });

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);

            //builder.HasOne(x => x.Product)
            //    .WithMany(x => x.OrderItems)
            //    .HasForeignKey(x => x.ProductId);
        }
    }
}

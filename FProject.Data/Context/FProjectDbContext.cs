using FProject.Data.Configuration;
using FProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Context
{
    public class FProjectDbContext : DbContext
    {
        public FProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new BasketConfiguration())
                .ApplyConfiguration(new BasketItemsConfiguration())
                .ApplyConfiguration(new BrandConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                //.ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new OrderConfiguration())
                .ApplyConfiguration(new OrderItemsConfiguration())
                .ApplyConfiguration(new ProductTypeConfiguration())
                //.ApplyConfiguration(new ExtraSubCategoryConfiguration())
                .ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        //public DbSet<ExtraSubCategory> ExtraSubCategories { get; set; }
        //public DbSet<CategorySubCategory> CategorySubCategories { get; set; }
        //public DbSet<SubCategoryExtraSubCategory> SubCategoryExtraSubCategories { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItems> BasketItems { get; set; }
    }
}

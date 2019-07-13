using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class ProductConverter
    {
        public static ProductDTO Convert(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new ProductDTO
            {
                Id = product.Id,
                Brand = BrandConverter.Convert(product.Brand),
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Title = product.Title,
                Type = ProductTypeConverter.Convert(product.Type)
            };
        }

        public static Product Convert(ProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Id = product.Id,
                Brand = BrandConverter.Convert(product.Brand),
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Title = product.Title,
                Type = ProductTypeConverter.Convert(product.Type)
            };
        }
    }
}

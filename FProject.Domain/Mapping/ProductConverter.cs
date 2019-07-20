using FProject.Contracts;
using FProject.Data.Entities;
using FProject.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Category = CategoryConverter.Convert(product.Category)
            };
        }

        public static Product Convert(ProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Id = product.Id,
                Brand = BrandConverter.Convert(product.Brand),
                BrandId = product.Brand.Id,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Title = product.Title,
                Category = CategoryConverter.Convert(product.Category),
                CategoryId = product.Category.Id
            };
        }

        public static Product Convert(CreateProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Title = product.Title,
                BrandId = product.BrandId,
                
                CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                IsDeleted = false
            };
        }

        public static List<ProductDTO> Convert(IEnumerable<Product> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));

            var dtos = products.Select(p => Convert(p)).ToList();
            return dtos;
        }

        public static UpdateProductDTO ConvertU(ProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new UpdateProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                //BrandId = product.BrandId,

                //CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                //IsDeleted = false
            };
        }

        public static ProductDTO Convert(UpdateProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new ProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                //BrandId = product.BrandId,
                
                //CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                //IsDeleted = false
            };
        }
    }
}

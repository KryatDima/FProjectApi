using FProject.Contracts;
using FProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Mapping
{
    public static class ProductDTOtoViewModel
    {
        public static ProductViewModel  Convert(ProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new ProductViewModel
            {
                Id = product.Id,
                BrandId = product.BrandId,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Title = product.Title,
                CategoryId = product.CategoryId
            };
        }

        public static List<ProductViewModel> Convert(IEnumerable<ProductDTO> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));

            var model = products.Select(p => Convert(p)).ToList();
            return model;
        }
    }
}

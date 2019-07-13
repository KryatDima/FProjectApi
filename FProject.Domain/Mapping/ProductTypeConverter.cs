using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class ProductTypeConverter
    {
        public static ProductTypeDTO Convert(ProductType type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return new ProductTypeDTO
            {
                Id = type.Id,
                Title=type.Title,
                Category=CategoryConverter.Convert(type.Category)
            };
        }

        public static ProductType Convert(ProductTypeDTO type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return new ProductType
            {
                Id = type.Id,
                Title = type.Title,
                Category = CategoryConverter.Convert(type.Category)
            };
        }
    }
}

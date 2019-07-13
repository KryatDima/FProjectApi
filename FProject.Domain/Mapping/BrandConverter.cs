using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class BrandConverter
    {
        public static BrandDTO Convert(Brand brand)
        {
            if (brand == null) throw new ArgumentNullException(nameof(brand));

            return new BrandDTO
            {
                Id = brand.Id,
                Description = brand.Description,
                Title = brand.Title
            };
        }
        public static List<BrandDTO> Convert(IEnumerable<Brand> brands)
        {
            if (brands == null) throw new ArgumentNullException(nameof(brands));

            var dtos = brands.Select(b => Convert(b)).ToList();
            return dtos;
        }

        public static Brand Convert(BrandDTO brand)
        {
            if (brand == null) throw new ArgumentNullException(nameof(brand));

            return new Brand
            {
                Id = brand.Id,
                Description = brand.Description,
                Title = brand.Title,
                IsDeleted = false,
            };
        }
    }
}

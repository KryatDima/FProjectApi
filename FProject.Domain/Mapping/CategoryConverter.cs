using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class CategoryConverter
    {
        public static CategoryDTO Convert(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            return new CategoryDTO
            {
                Id = category.Id,
                Title = category.Title,
                ParentCategory=Convert(category.ParentCategory)
            };
        }

        public static Category Convert(CategoryDTO category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            return new Category
            {
                Id = category.Id,
                Title = category.Title,
                ParentCategory = Convert(category.ParentCategory)
            };
        }
    }
}

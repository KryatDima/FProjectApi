using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class CategoryConverter
    {
        public static CategoryDTO Convert(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            var dto = new CategoryDTO
            {
                Id = category.Id,
                Title = category.Title,
            };
            if (category.ParentCategoryId != null && category.ParentCategory != null)
            {
                dto.ParentCategory = Convert(category.ParentCategory);
            }

            return dto;
        }

        public static Category Convert(CategoryDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var category= new Category
            {
                Id = dto.Id,
                Title = dto.Title
            };
            if (dto.ParentCategory != null)
            {
                category.ParentCategoryId = dto.ParentCategory.Id;
                category.ParentCategory = Convert(dto.ParentCategory);
            };

            return category;
        }

        public static Category Convert(CreateCategoryDTO category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            return new Category
            {
                Title = category.Title,
                ParentCategoryId = category.ParentCategoryId,
                IsDeleted = false
            };
        }

        public static Category Convert(UpdateCategoryDTO category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            return new Category
            {
                Id = category.Id,
                Title = category.Title,
                ParentCategoryId = category.ParentCategoryId,
                IsDeleted = false
            };
        }

        public static List<CategoryDTO> Convert(List<Category> categories)
        {
            if(categories==null) throw new ArgumentNullException(nameof(categories));

            var dtos = categories.Select(x => Convert(x)).ToList();
            return dtos;
        }
    }
}

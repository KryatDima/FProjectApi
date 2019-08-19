using FProject.Contracts;
using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using FProject.Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CategoryDTO> Add(CreateCategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return null;

            if (categoryDTO.ParentCategoryId != null && await Get(categoryDTO.ParentCategoryId.Value) == null)
                return null;

            var entity = await unitOfWork.Repository<Category>().Add(CategoryConverter.Convert(categoryDTO));


            if (entity == null) return null;
            if (entity.ParentCategoryId != null)
            {
                entity.ParentCategory = await unitOfWork.Repository<Category>().Get(entity.ParentCategoryId.Value);
            }
            return CategoryConverter.Convert(entity);
        }

        public async Task<CategoryDTO> Get(long id)
        {
            var category = await GetCategoryEntity(id);
            if (category == null) return null;
            return CategoryConverter.Convert(category);
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            var categories = unitOfWork.Repository<Category>().GetQueryable()
                .Include(x => x.ParentCategory)
                .Where(x=>x.IsDeleted!=true)
                .ToList();

            if (categories == null) return null;
            return await Task.FromResult(CategoryConverter.Convert(categories));
        }

        public async Task<CategoryDTO> Update(UpdateCategoryDTO dto) // update dto
        {
            if (dto == null) return null;
            var entity = CategoryConverter.Convert(dto);
            entity = await unitOfWork.Repository<Category>().Update(entity);
            return CategoryConverter.Convert(entity);
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await GetCategoryEntity(id);
            if (entity == null) return false;
            entity.IsDeleted = true;
            entity = await unitOfWork.Repository<Category>().Update(entity);
            return entity.IsDeleted;
        }

        private async Task<Category> GetCategoryEntity(long id) => await unitOfWork.Repository<Category>().GetQueryable()
            .Include(x => x.ParentCategory)
            .SingleOrDefaultAsync(c => c.Id == id);
    }
}

using FProject.Contracts;
using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork unitOfWork;

        public async Task<Category> Add(CreateCategoryDTO categoryDTO)
        {
            return await unitOfWork.Repository<Category>().Add(new Category
            {
                Title=categoryDTO.Title,
                ParentCategoryId=categoryDTO.ParentCategoryId
            });
        }

        public Task<CategoryDTO> Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}

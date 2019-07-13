using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface ICategoryService
    {
        Task<Category> Add(CreateCategoryDTO categoryDTO);
        Task<CategoryDTO> Get(long id);
    }
}

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
        Task<CategoryDTO> Add(CreateCategoryDTO categoryDTO);
        Task<CategoryDTO> Update(UpdateCategoryDTO dto);
        Task<bool> Delete(long id);
        Task<CategoryDTO> Get(long id);
        Task<List<CategoryDTO>> GetAll();
    }
}

using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IProductTypeService
    {
        Task<ProductType> Add(CreateProductTypeDTO categoryDTO);
        Task<ProductTypeDTO> Get(long id);
    }
}

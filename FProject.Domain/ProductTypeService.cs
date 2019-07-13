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
    public class ProductTypeService : IProductTypeService
    {
        public IUnitOfWork unitOfWork;
        public async Task<ProductType> Add(CreateProductTypeDTO categoryDTO)
        {
            return await unitOfWork.Repository<ProductType>().Add(new ProductType
            {
                CategoryId = categoryDTO.CategoryId,
                Title = categoryDTO.Title,
                IsDeleted = false
            });
        }

        public Task<ProductTypeDTO> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductType> Delete(long id)
        {
            //return unitOfWork.Repository<ProductType>().Delete();
            throw new NotImplementedException();
        }
    }
}

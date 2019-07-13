using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IBrandService
    {
        Task<BrandDTO> Add(CreateBrandDTO brandDTO);
        Task<BrandDTO> Update(BrandDTO dto);
        Task<bool> Delete(long id);
        Task<BrandDTO> Get(long id);
        List<BrandDTO> GetAll();
    }
}

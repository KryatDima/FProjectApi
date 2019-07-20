using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IProductService
    {
        Task<ProductDTO> Get(long id);
        Task<List<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetListBySearchQuery(string searchQuery);
        Task<IEnumerable<ProductDTO>> GetListByFilters(Params param);
        Task<ProductDTO> Add(CreateProductDTO productDTO);
        Task<ProductDTO> Update(UpdateProductDTO dto);
        Task<bool> Delete(long id);
    }
}

using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IProductService
    {
        Task<Product> Get(long id);
        Task<List<Product>> GetListBySearchQuery(string searchQuery);
        Task<List<Product>> GetListByFilters(Params param);
    }
}

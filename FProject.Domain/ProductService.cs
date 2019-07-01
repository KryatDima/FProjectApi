using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FProject.Domain
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> Get(long id)
        {
            return await unitOfWork.Repository<Product>().Get(id);
            
        }

        public async Task<List<Product>> GetListByFilters(Params param)
        {
            return await unitOfWork.Repository<Product>().GetQueryable().Where(x => x.BrandId == param.BrandId)
                .Where(x => x.ProductTypeId == param.TypeId)
                .Where(x => x.Price >= param.PriceFrom && x.Price <= param.PriceTo)
                .ToListAsync();
        }

        public async Task<List<Product>> GetListBySearchQuery(string searchQuery)
        {
            return await unitOfWork.Repository<Product>().GetQueryable().Where(x => x.Title.StartsWith(searchQuery)).ToListAsync();
        }
    }
}

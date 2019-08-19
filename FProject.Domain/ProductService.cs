using FProject.Contracts;
using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using FProject.Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProject.Domain
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private async Task<Product> GetProductEntity(long id)
        {
            var product= await unitOfWork.Repository<Product>().GetQueryable()
                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var products = await GetProductList();

            if (products == null) return null;

            return ProductConverter.Convert(products);
        }

        private async Task<IQueryable<Product>> GetProductList()
        {
            var dtos = unitOfWork.Repository<Product>().GetQueryable().Where(x=>x.IsDeleted==false);

            return await Task.FromResult(dtos);
        }

        public async Task<ProductDTO> Get(long id)
        {
            var product = await GetProductEntity(id);

            if (product == null) return null;
            return ProductConverter.Convert(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetListByFilters(Params param = null)
        {
            var dtos = await GetProductList();
            if(param != null)
            {
                if (param.BrandId != null)
                {
                    dtos = dtos.Where(x => x.BrandId == param.BrandId);
                }

                if (param.CategoryId != null)
                {
                    dtos = dtos.Where(x => x.CategoryId == param.CategoryId);
                }

                if (param.PriceFrom != null)
                {
                    dtos = dtos.Where(x => x.Price >= param.PriceFrom);
                }

                if (param.PriceTo != null)
                {
                    dtos = dtos.Where(x => x.Price <= param.PriceTo);
                }                    
            }
            return ProductConverter.Convert(dtos);
        }

        public async Task<IEnumerable<ProductDTO>> GetListBySearchQuery(string searchQuery)
        {
            var entity = await unitOfWork.Repository<Product>().GetQueryable()
                .Where(x => x.Title.Contains(searchQuery))
                .Where(x => x.IsDeleted!=true)
                .ToListAsync();

            if (entity == null) return null;
            return ProductConverter.Convert(entity);
        }

        public async Task<ProductDTO> Add(CreateProductDTO productDTO)
        {
            if (productDTO == null) return null;
            var p = ProductConverter.Convert(productDTO);
            var product = await unitOfWork.Repository<Product>().Add(p);

            return ProductConverter.Convert(product);
        }

        public async Task<ProductDTO> Update(UpdateProductDTO updateDto)
        {
            if (updateDto == null) return null;
            var dto = ProductConverter.Convert(updateDto);
            var product = ProductConverter.Convert(dto);
            product = await unitOfWork.Repository<Product>().Update(product);
            return ProductConverter.Convert(product);
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await GetProductEntity(id);
            if (entity == null) return false;
            entity.IsDeleted = true;
            entity = await unitOfWork.Repository<Product>().Update(entity);
            return entity.IsDeleted;
        }
    }
}

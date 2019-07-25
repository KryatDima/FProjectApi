using FProject.Contracts;
using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using FProject.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BrandDTO> Add(CreateBrandDTO brandDTO) // TODO add mapping for CreateBrandDto  +
        {
            var entity = await unitOfWork.Repository<Brand>().Add(BrandConverter.Convert(brandDTO));

            if (entity == null) return null;
            return BrandConverter.Convert(entity);
        }

        public async Task<BrandDTO> Update(BrandDTO dto)
        {
            if (dto == null) return null;
            var entity = BrandConverter.Convert(dto);
            entity = await unitOfWork.Repository<Brand>().Update(entity);
            return BrandConverter.Convert(entity);
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await GetBrandEntity(id);
            if (entity == null) return false;
            entity.IsDeleted = true;
            entity = await unitOfWork.Repository<Brand>().Update(entity);
            return entity.IsDeleted;
        }

        public async Task<BrandDTO> Get(long id)
        {
            var brand = await GetBrandEntity(id);
            if (brand == null) return null;
            return BrandConverter.Convert(brand);
        }

        public List<BrandDTO> GetAll()
        {
            var brands = unitOfWork.Repository<Brand>().GetQueryable().Where(b => b.IsDeleted == false);
            if (brands == null) return null;
            return BrandConverter.Convert(brands);
        }

        private async Task<Brand> GetBrandEntity(long id) => await unitOfWork.Repository<Brand>().Get(id);
    }
}

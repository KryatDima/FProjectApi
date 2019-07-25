using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FProject.Contracts;
using FProject.Domain.Mapping;

namespace FProject.Domain
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductService productService;

        public BasketService(IUnitOfWork unitOfWork, IProductService productService)
        {
            this.unitOfWork = unitOfWork;
            this.productService = productService;
        }

        public async Task<BasketDTO> GetBasketByUserId(long userId)
        {
            var basket = await unitOfWork.Repository<Basket>().GetQueryable()
                .AsNoTracking()
                .Include(b => b.BasketItems)
                .Include(u => u.User)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (basket == null || basket.User == null) return null;

            basket.BasketItems = unitOfWork.Repository<BasketItems>().GetQueryable().Where(b => b.BasketId == basket.Id).ToList();
            var basketdto = BasketConverter.Convert(basket);
            return basketdto;
        }

        public async Task<BasketDTO> AddItem(CreateBasketItemsDTO dto, long userId)
        {
            if (dto == null) return null;
            var basket = await GetBasketByUserId(userId);
            basket.BasketItems = basket.BasketItems ?? new List<BasketItemsDTO>();
            var _item = basket.BasketItems.SingleOrDefault(x=>x.ProductId==dto.ProductId);
            if (_item != null)
            {
                var product = await productService.Get(_item.ProductId);
                if (_item != null && product.Quantity >= dto.Quantity + _item.Quantity)
                {
                    _item.Quantity += dto.Quantity;
                }

                await unitOfWork.Repository<BasketItems>().Update(BasketItemsConverter.Convert(_item));
            }
            else
            {
                var item = BasketItemsConverter.Convert(dto);
                var productDto = await productService.Get(item.ProductId);
                item = await unitOfWork.Repository<BasketItems>().Add(item);
                basket.BasketItems.Add(BasketItemsConverter.Convert(dto, item.Id));
            }
            return basket;
        }

        public async Task<BasketDTO> DeleteAllItems(long userId)
        {
            var basket = await GetBasketByUserId(userId);///??
            if (basket == null || !basket.BasketItems.Any())
                return null;

            basket.BasketItems.Clear();
            var result = unitOfWork.Repository<BasketItems>().Delete(BasketItemsConverter.Convert(basket.BasketItems));
            if (!result) return null;

            return basket;
        }

        public async Task<BasketDTO> Delete(BasketItemsDTO item, long userId)
        {
            var basket = await GetBasketByUserId(userId);///??
            if (basket == null)
                return null;

            if (!basket.BasketItems.Any())
                return basket;

            basket.BasketItems.Remove(item);
            var result = unitOfWork.Repository<BasketItems>().Delete(BasketItemsConverter.Convert(item));
            if (!result) return null;
            await unitOfWork.SaveChangesAsync();

            return basket;
        }

        public async Task<BasketDTO> Get(long id)
        {
            var basket = await unitOfWork.Repository<Basket>().GetQueryable().Where(x => x.Id == id)
                .Include(x => x.BasketItems)
                .FirstOrDefaultAsync();

            if (basket == null) return null;
            return BasketConverter.Convert(basket);
        }

        public async Task<BasketDTO> Create(long userId)
        {
            var user = await unitOfWork.UserRepository.Get(userId); // null
            var basket = new CreateBasketDTO
            {
                User = UserConverter.Convert(user)
            };
            var entity = await unitOfWork.Repository<Basket>().Add(BasketConverter.Convert(basket));

            if (entity == null) return null;
            return BasketConverter.Convert(entity);
        }
    }
}

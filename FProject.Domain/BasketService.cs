using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FProject.Domain
{
    public class BasketService : IBasketService
    {
        public IUnitOfWork unitOfWork;



        public async Task<Basket> GetBasketByUserId(long userId)
        {
            return await unitOfWork.BasketRepository.GetBasketByUserId(userId);
        }
        public BasketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //public void add(long id)
        //{
        //    unitofwork.basketitemrepository.
        //}


        public async Task AddItem(long productId, long userId, int _quantity)
        {
            var basket = await GetBasketByUserId(userId);
            var _item = basket.BasketItems.FirstOrDefault(x=>x.ProductId==productId);
            if (_item != null)
            {
                _item.Quantity += 1;
            }
            else
            {
                var item = new BasketItems { ProductId = productId, Quantity = _quantity, BasketId = basket.Id };
                unitOfWork.BasketItemRepository.AddItem(item);
                basket.BasketItems.Add(item);
                await unitOfWork.SaveChangesAsync();
            }
                
            //unitOfWork.BasketItemRepository.AddItem(item);
        }

        public async  void DeleteAllItems(long userId)
        {
            var basket =  await GetBasketByUserId(userId);
            unitOfWork.BasketItemRepository.Delete(basket.BasketItems);
        }

        public void Delete(BasketItems items)
        {
            unitOfWork.BasketItemRepository.Delete(items);

        }

        public async Task<Basket> Get(long id)
        {
            return await unitOfWork.Repository<Basket>().GetQueryable().Where(x=>x.Id==id)
                .Include(x => x.BasketItems)
                    .ThenInclude(x=>x.Product)
                .FirstOrDefaultAsync();
        }
    }
}

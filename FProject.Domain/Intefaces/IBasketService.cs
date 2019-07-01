using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IBasketService
    {
        Task<Basket> Get(long id);
        //Task<Basket> Add(long id);
        Task<Basket> GetBasketByUserId(long userId);
        Task AddItem(long productId, long userId, int _quantity);
        void Delete(BasketItems item);
        void DeleteAllItems(long userId);

        //void DeleteAllItems(long userId);
        
    }
}

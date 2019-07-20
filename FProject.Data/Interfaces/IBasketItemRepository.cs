using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.Interfaces
{
    public interface IBasketItemRepository
    {
        Task<BasketItems> Update(BasketItems item);
        bool Delete(BasketItems item);
        void AddItem(BasketItems item);
        bool Delete(IReadOnlyCollection<BasketItems> entities);
        List<BasketItems> Get(long basketId);
    }
}

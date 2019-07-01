using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.Interfaces
{
    public interface IBasketItemRepository
    {
        void Delete(BasketItems item);
        void AddItem(BasketItems item);
        void Delete(IReadOnlyCollection<BasketItems> entities);

    }
}

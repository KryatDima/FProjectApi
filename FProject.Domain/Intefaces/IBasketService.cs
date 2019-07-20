using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IBasketService
    {
        Task<BasketDTO> Create(long userId);
        Task<BasketDTO> Get(long id);
        Task<BasketDTO> GetBasketByUserId(long userId);
        Task<BasketDTO> AddItem(CreateBasketItemsDTO dto,long userId);
        Task<BasketDTO> Delete(BasketItemsDTO item, long userId);
        Task<BasketDTO> DeleteAllItems(long userId);
    }
}

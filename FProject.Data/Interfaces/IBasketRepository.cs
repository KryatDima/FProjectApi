using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Data.Interfaces
{
    public interface IBasketRepository :IRepository<Basket> 
    {
        Task<Basket> GetBasketByUserId(long userId); 
    }
}

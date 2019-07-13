using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class BasketConverter
    {
        public static BasketDTO Convert(Basket basket)
        {
            if (basket == null) throw new ArgumentNullException(nameof(basket));

                return new BasketDTO
                {
                    Id = basket.Id,
                    BasketItems=BasketItemsConverter.Convert(basket.BasketItems),
                    User=UserConverter.Convert(basket.User)
                };
            
        }
    }
}

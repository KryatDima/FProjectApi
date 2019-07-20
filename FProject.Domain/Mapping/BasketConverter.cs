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

                //return new BasketDTO
                //{
                //    Id = basket.Id,
                //    BasketItems=BasketItemsConverter.Convert(basket.BasketItems),
                //    User=UserConverter.Convert(basket.User)
                //};
            var dto = new BasketDTO
            {
                Id = basket.Id,
                User=UserConverter.Convert(basket.User)
            };
            if (basket.BasketItems != null)
            {
                dto.BasketItems = BasketItemsConverter.Convert(basket.BasketItems);
            }
            return dto;
        }

        public static Basket Convert(BasketDTO basket)
        {
            if (basket == null) throw new ArgumentNullException(nameof(basket));

            return new Basket
            {
                Id = basket.Id,
                UserId = basket.User.Id,
                BasketItems = BasketItemsConverter.Convert(basket.BasketItems),
                User = UserConverter.Convert(basket.User)
            };
        }

        public static Basket Convert(CreateBasketDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new Basket
            {
                User = UserConverter.Convert(dto.User),
                UserId = dto.User.Id
            };
        }
    }
}

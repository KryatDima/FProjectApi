﻿using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class BasketItemsConverter
    {
        public static BasketItemsDTO Convert(BasketItems basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            return new BasketItemsDTO
            {
                Id = basketItems.Id,
                ProductId = basketItems.ProductId,
                Quantity = basketItems.Quantity,
                BasketId = basketItems.BasketId
            };
        }

        public static BasketItems Convert(BasketItemsDTO basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            return new BasketItems
            {
                Id = basketItems.Id,
                ProductId = basketItems.ProductId,
                Quantity = basketItems.Quantity,
                BasketId = basketItems.BasketId
            };
        }

        public static BasketItems Convert(CreateBasketItemsDTO basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            return new BasketItems
            {
                ProductId = basketItems.ProductId,
                Quantity = basketItems.Quantity,
                BasketId = basketItems.BasketId
            };
        }

        public static BasketItemsDTO Convert(CreateBasketItemsDTO basketItems, long id)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            return new BasketItemsDTO
            {
                Id = id,
                ProductId = basketItems.ProductId,
                Quantity = basketItems.Quantity,
                BasketId = basketItems.BasketId
            };
        }

        public static List<BasketItemsDTO> Convert(List<BasketItems> basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            var basketitemslist = basketItems.Select(x => Convert(x)).ToList();
            return basketitemslist;
        }

        public static List<BasketItems> Convert(List<BasketItemsDTO> basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            var basketitemslist = basketItems.Select(x => Convert(x)).ToList();
            return basketitemslist;
        }
    }
}

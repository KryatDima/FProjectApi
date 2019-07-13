using FProject.Contracts;
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
                Product = ProductConverter.Convert(basketItems.Product),
                Quantity = basketItems.Quantity,
                Basket = BasketConverter.Convert(basketItems.Basket)
            };
        }

        public static List<BasketItemsDTO> Convert(List<BasketItems> basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            var basketitemslist = basketItems.Select(x => Convert(x)).ToList();
            return basketitemslist;
        }
    }
}

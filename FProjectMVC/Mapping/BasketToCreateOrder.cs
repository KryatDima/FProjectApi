using FProject.Contracts;
using FProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Mapping
{
    public class BasketToCreateOrder
    {
        public static OrderItemsDTO Convert(OrderItemViewModel items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return new OrderItemsDTO
            {
                //OrderId=select
                Quantity = items.Quantity,
                Product = items.Product
            };
        }
        public static List<OrderItemsDTO> Convert(List<OrderItemViewModel> basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            var orderItemsList = basketItems.Select(b => Convert(b)).ToList();
            return orderItemsList;
        }
        public static OrderItemViewModel Convert(BasketItemViewModel items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return new OrderItemViewModel
            {
                //OrderId=select
                Quantity = items.Quantity,
                Product=items.product
            };
        }
        public static OrderItemsDTO ConvertD(BasketItemsDTO basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            return new OrderItemsDTO
            {
                //Product = basketItems.Product,
                Quantity = basketItems.Quantity,
                //OrderId = // set some value
            };
        }

        public static List<OrderItemViewModel> Convert(List<BasketItemViewModel> basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            var orderItemsList = basketItems.Select(b => Convert(b)).ToList();
            return orderItemsList;
        }
        public static OrderItemViewModel ConvertD(BasketItemViewModel items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return new OrderItemViewModel
            {
                Product=items.product,
                Quantity=items.Quantity
            };
        }

        public static List<OrderItemViewModel> Convert(IEnumerable<BasketItemViewModel> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var model = items.Select(p => Convert(p)).ToList();
            return model;
        }
    }
}

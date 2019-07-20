using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class OrderItemsConverter
    {
        public static OrderItemsDTO Convert(OrderItems orderItems)
        {

            if (orderItems == null) throw new ArgumentNullException(nameof(orderItems));

            return new OrderItemsDTO
            {
                OrderId = orderItems.OrderId,
                Product = ProductConverter.Convert(orderItems.Product),
                Quantity = orderItems.Quantity
                
            };
        }

        public static OrderItems Convert(OrderItemsDTO orderItems)
        {

            if (orderItems == null) throw new ArgumentNullException(nameof(orderItems));

            return new OrderItems
            {
                Product = ProductConverter.Convert(orderItems.Product),
                Quantity = orderItems.Quantity,
                OrderId = orderItems.OrderId,
                ProductId=orderItems.Product.Id,
            };
        }

        public static List<OrderItemsDTO> Convert(List<OrderItems> orderItems)
        {
            if (orderItems == null) throw new ArgumentNullException(nameof(orderItems));

            var orderitemslist = orderItems.Select(x => Convert(x)).ToList();
            return orderitemslist;
        }

        public static List<OrderItems> Convert(List<OrderItemsDTO> orderItems)
        {
            if (orderItems == null) throw new ArgumentNullException(nameof(orderItems));

            var orderitemslist = orderItems.Select(x => Convert(x)).ToList();
            return orderitemslist;
        }

        public static OrderItemsDTO Convert(BasketItemsDTO basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            return new OrderItemsDTO
            {
                //Product = basketItems.Product,
                Quantity = basketItems.Quantity,
                //OrderId = // set some value
            };
        }

        public static List<OrderItemsDTO> Convert(List<BasketItemsDTO> basketItems)
        {
            if (basketItems == null) throw new ArgumentNullException(nameof(basketItems));

            var orderItemsList = basketItems.Select(b => Convert(b)).ToList();
            return orderItemsList;
        }
    }
}

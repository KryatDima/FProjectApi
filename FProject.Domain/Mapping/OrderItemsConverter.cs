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
                Order = OrderConverter.Convert(orderItems.Order),
                Product = ProductConverter.Convert(orderItems.Product),
                Quantity = orderItems.Quantity

            };
        }

        public static List<OrderItemsDTO> Convert(List<OrderItems> orderItems)
        {
            if (orderItems == null) throw new ArgumentNullException(nameof(orderItems));

            var orderitemslist = orderItems.Select(x => Convert(x)).ToList();
            return orderitemslist;
        }
    }
}

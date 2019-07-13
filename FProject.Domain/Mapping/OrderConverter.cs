using FProject.Contracts;
using FProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FProject.Domain.Mapping
{
    public static class OrderConverter
    {
        public static OrderDTO Convert(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            return new OrderDTO
            {
                Id = order.Id,
                Comment = order.Comment,
                User = UserConverter.Convert(order.User),
                OrderItems = OrderItemsConverter.Convert(order.OrderItems),
                TotalPrice = order.OrderItems.Select(p => p.Product.Price).Sum()
            };
        }
    }
}

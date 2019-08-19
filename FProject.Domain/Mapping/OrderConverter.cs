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
        public static Order Convert(CreateOrderDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new Order
            {
                
                Comment = dto.Comment,
                User = UserConverter.Convert(dto.User),
                UserId=dto.User.Id,
                OrderItems = OrderItemsConverter.Convert(dto.OrderItems),
                TotalPrice = dto.OrderItems.Select(p => p.Product.Price).Sum()
            };
        }
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

        public static Order Convert(OrderDTO order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            return new Order
            {
                Id = order.Id,
                Comment = order.Comment,
                User = UserConverter.Convert(order.User),
                OrderItems = OrderItemsConverter.Convert(order.OrderItems),
                TotalPrice = order.OrderItems.Select(p => p.Product.Price).Sum(),
                UserId = order.User.Id,
            };
        }

        public static List<OrderDTO> Convert(IEnumerable<Order> order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            var dtos = order.Select(o => Convert(o)).ToList();
            return dtos;
        }

        public static OrderDTO Convert(BasketDTO basketDTO)
        {
            if (basketDTO == null) throw new ArgumentNullException(nameof(basketDTO));

            return new OrderDTO
            {
                //TotalPrice = basketDTO.BasketItems.Select(p => p.Product.Price).Sum(),
                User = basketDTO.User,
                OrderItems = OrderItemsConverter.Convert(basketDTO.BasketItems)
            };
        }
    }
}

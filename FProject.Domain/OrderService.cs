using FProject.Contracts;
using FProject.Data.Entities;
using FProject.Data.Interfaces;
using FProject.Domain.Intefaces;
using FProject.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderDTO> Create(BasketDTO dto, string comment/*, string address*/)
        {
            var orderDto = OrderConverter.Convert(dto);
            orderDto.Comment = comment;
            var order = OrderConverter.Convert(orderDto);
            order.IsDeleted = false;
            var a = await unitOfWork.Repository<Order>().Add(order);
            return orderDto;
        }

        public async Task<OrderDTO> Get(long id)
        {
            return OrderConverter.Convert(await unitOfWork.Repository<Order>().Get(id));
        }

        public async Task<List<OrderDTO>> GetAllForUser(long userId)
        {
            var orders = unitOfWork.Repository<Order>().GetQueryable().Where(u => u.UserId == userId);
            if (orders == null)
                return null;
            return await Task.FromResult(OrderConverter.Convert(orders));
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            var orders = unitOfWork.Repository<Order>().GetQueryable();
            if (orders == null)
                return null;
            return await Task.FromResult(OrderConverter.Convert(orders));
        }

        private async Task<OrderDTO> GetOrderEntity(long id)
        {
            var order = await unitOfWork.Repository<Order>().Get(id);
            order.User = await unitOfWork.Repository<User>().Get(order.UserId);
            return OrderConverter.Convert(order);
        }
    }
}

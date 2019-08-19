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
        private readonly IBasketService basketService;
        public OrderService(IUnitOfWork unitOfWork,IBasketService basketService)
        {
            this.unitOfWork = unitOfWork;
            this.basketService = basketService;

        }

        public async Task<OrderDTO> Create(CreateOrderDTO dto)
        {
            if (dto == null) return null;
            //var orderDto = OrderConverter.Convert(dto);
            //orderDto.Comment = comment;
            var order = OrderConverter.Convert(dto);
            order.IsDeleted = false;
            var a = await unitOfWork.Repository<Order>().Add(order);
            await basketService.DeleteAllItems(a.UserId);
            return OrderConverter.Convert(a);
        }

        public async Task<OrderDTO> Get(long id)
        {
            var order = await unitOfWork.Repository<Order>().Get(id);
            if (order == null) return null;
            return OrderConverter.Convert(order);
        }

        public async Task<List<OrderDTO>> GetAllForUser(long userId)
        {
            var orders = unitOfWork.Repository<Order>().GetQueryable().Where(u => u.UserId == userId).Where(x=>x.IsDeleted!=true);
            if (orders == null)
                return null;
            return await Task.FromResult(OrderConverter.Convert(orders));
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            var orders = unitOfWork.Repository<Order>().GetQueryable().Where(x=>x.IsDeleted!=true);
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

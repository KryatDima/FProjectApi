using FProject.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IOrderService
    {
        Task<OrderDTO> Create(CreateOrderDTO dto);
        Task<OrderDTO> Get(long id);
        Task<List<OrderDTO>> GetAllForUser(long userId);
        Task<List<OrderDTO>> GetAll();
    }
}

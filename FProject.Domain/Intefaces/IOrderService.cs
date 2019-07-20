﻿using FProject.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FProject.Domain.Intefaces
{
    public interface IOrderService
    {
        Task<OrderDTO> Create(BasketDTO dto, string comment/*, string address*/);
        Task<OrderDTO> Get(long id);
    }
}

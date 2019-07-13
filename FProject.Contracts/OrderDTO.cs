using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class OrderDTO
    {
        public long Id { get; set; }

        public UserDTO User { get; set; }

        public string Comment { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemsDTO> OrderItems { get; set; }
    }
}

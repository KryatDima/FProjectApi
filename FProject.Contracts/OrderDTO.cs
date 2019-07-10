using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class OrderDTO
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public virtual UserDTO User { get; set; }

        public string Comment { get; set; }
        //public double Cost { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<OrderItemsDTO> OrderItems { get; set; }
    }
}

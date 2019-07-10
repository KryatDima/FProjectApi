using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class OrderItemsDTO
    {
        public long OrderId { get; set; }
        public virtual OrderDTO Order { get; set; }

        public long ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }

        public int Quantity { get; set; }
    }
}

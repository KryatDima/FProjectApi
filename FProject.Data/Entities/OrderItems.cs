using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Entities
{
    public class OrderItems
    {
        public long OrderId { get; set; }
        

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}

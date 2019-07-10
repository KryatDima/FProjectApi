using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class BasketItemsDTO
    {
        public long BasketId { get; set; }
        public virtual BasketDTO Basket { get; set; }

        public long ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }

        public int Quantity { get; set; }
    }
}

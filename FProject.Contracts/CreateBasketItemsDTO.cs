using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class CreateBasketItemsDTO
    {
        public long BasketId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

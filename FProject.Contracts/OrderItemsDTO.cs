﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class OrderItemsDTO
    {
        public long OrderId { get; set; }

        public ProductDTO Product { get; set; }

        public int Quantity { get; set; }
    }
}

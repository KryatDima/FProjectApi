﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public CategoryDTO Category { get; set; }

        public BrandDTO Brand { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}

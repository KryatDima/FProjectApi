using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class CreateProductDTO
    {
        public string Title { get; set; }

        public long TypeId { get; set; }

        public long BrandId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class UpdateProductDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public long CategoryId { get; set; }

        public long BrandId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}

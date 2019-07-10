using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public long ProductTypeId { get; set; }
        public virtual ProductTypeDTO Type { get; set; }

        public long BrandId { get; set; }
        public virtual BrandDTO Brand { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<BasketItemsDTO> BasketItems { get; set; }

        public virtual List<OrderItemsDTO> OrderItems { get; set; }
    }
}

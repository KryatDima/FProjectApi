using FProject.Data.Interfaces;
using System.Collections.Generic;

namespace FProject.Data.Entities
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }

        //public long CategoryId { get; set; }
        //public Category Category { get; set; }

        public long ProductTypeId { get; set; }
        public virtual ProductType Type { get; set; }

        public long BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<BasketItems> BasketItems { get; set; }

        public virtual List<OrderItems> OrderItems { get; set; }
    }
}

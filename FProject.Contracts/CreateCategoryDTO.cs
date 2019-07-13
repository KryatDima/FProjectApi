using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class CreateCategoryDTO
    {
        public string Title { get; set; }
        public long? ParentCategoryId { get; set; }
        //public virtual Category ParentCategory { get; set; }
        //public virtual List<ProductType> ProductTypes { get; set; }
    }
}

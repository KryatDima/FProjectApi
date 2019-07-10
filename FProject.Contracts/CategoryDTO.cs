using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentCategoryId { get; set; }
        public virtual CategoryDTO ParentCategory { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<ProductTypeDTO> ProductTypes { get; set; }
    }
}

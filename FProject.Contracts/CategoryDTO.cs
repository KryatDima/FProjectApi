using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public CategoryDTO ParentCategory { get; set; }
        public List<ProductTypeDTO> ProductTypes { get; set; }
    }
}

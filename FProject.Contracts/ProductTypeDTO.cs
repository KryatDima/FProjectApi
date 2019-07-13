using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class ProductTypeDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public CategoryDTO Category { get; set; }
    }
}

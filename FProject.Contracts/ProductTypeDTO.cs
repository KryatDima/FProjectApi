using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class ProductTypeDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public long CategoryId { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}

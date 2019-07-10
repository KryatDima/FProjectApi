using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class BrandDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}

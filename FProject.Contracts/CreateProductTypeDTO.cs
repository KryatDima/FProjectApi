using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class CreateProductTypeDTO
    {
        public string Title { get; set; }

        public long CategoryId { get; set; }
    }
}

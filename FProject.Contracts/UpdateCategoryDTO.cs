using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class UpdateCategoryDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ParentCategoryId { get; set; }
    }
}

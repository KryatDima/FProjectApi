using FProject.Data.Interfaces;
using System.Collections.Generic;

namespace FProject.Data.Entities
{
    public class Category : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using FProject.Data.Interfaces;

namespace FProject.Data.Entities
{
    public class ProductType : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }

        
        
    }
}

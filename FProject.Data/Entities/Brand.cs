using FProject.Data.Interfaces;

namespace FProject.Data.Entities
{
    public class Brand : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

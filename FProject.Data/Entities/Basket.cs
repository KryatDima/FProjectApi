using System.Collections.Generic;
using FProject.Data.Interfaces;

namespace FProject.Data.Entities
{
    public class Basket : IEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        //public int Quantity { get; set; }
        //public double Cost { get; set; }

        public virtual List<BasketItems> BasketItems { get; set; }
    }
}

using FProject.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Data.Entities
{
    public class BasketItems: IEntity
    {
        public long Id { get; set; }
        public long BasketId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

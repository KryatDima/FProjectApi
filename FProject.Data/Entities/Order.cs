﻿using FProject.Data.Interfaces;
using System.Collections.Generic;

namespace FProject.Data.Entities
{
    public class Order : IEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public string Comment { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<OrderItems> OrderItems { get; set; }
    }
}

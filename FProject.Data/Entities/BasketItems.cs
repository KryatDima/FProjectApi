using FProject.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FProject.Data.Entities
{
    public class BasketItems: IEntity
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long BasketId { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}

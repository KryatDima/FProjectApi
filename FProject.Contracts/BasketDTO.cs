using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class BasketDTO
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual List<BasketItemsDTO> BasketItems { get; set; }
    }
}

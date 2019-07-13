using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Contracts
{
    public class BasketDTO
    {
        public long Id { get; set; }

        public UserDTO User { get; set; }
        public List<BasketItemsDTO> BasketItems { get; set; }
    }
}

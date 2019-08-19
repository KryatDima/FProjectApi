using FProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Models
{
    public class BasketItemViewModel:BasketItemsDTO
    {
        
        public ProductViewModel product { get; set; }
    }
}

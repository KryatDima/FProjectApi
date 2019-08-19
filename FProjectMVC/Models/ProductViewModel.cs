using FProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Models
{
    public class ProductViewModel:ProductDTO
    {
        public BrandDTO brand { get; set; }
        public CategoryDTO category { get; set; }
    }
}

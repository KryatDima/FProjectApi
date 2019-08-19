using FProject.Contracts;
using FProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Models
{
    public class ProductListViewModel:Params
    {
        public ProductListViewModel()
        {
            Products = new List<ProductViewModel>();
        }
        public List<ProductViewModel> Products { get; set; }
        public List<BrandViewModel> brands { get; set; }
        public List<CategoryViewModel> categories { get; set; }
    }
}

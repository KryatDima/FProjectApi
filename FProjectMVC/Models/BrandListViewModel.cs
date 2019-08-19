using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Models
{
    public class BrandListViewModel
    {
        public BrandListViewModel()
        {
            Brands = new List<BrandViewModel>();
        }
        public List<BrandViewModel> Brands { get; set; }
    }
}

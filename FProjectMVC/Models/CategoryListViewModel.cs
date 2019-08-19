using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Models
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }
        public List<CategoryViewModel> Categories { get; set; }
    }
}

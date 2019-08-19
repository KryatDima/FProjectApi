using FProject.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FProjectMVC.Models
{
    public class CreateProductViewModel:CreateProductDTO
    {
        public SelectList brands { get; set; }
        public SelectList categories { get; set; }
    }
}

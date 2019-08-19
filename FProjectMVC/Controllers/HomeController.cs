using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FProjectMVC.Models;
using System.Net.Http;
using FProject.Contracts;

namespace FProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        //https://localhost:44309/api/
        public IActionResult Index()
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/product").Result;
            if (result.IsSuccessStatusCode)
            {
                list = result.Content.ReadAsAsync<List<ProductViewModel>>().Result;
            }
            foreach(var item in list)
            {
                result = client.GetAsync("https://localhost:44309/api/brand/"+item.BrandId).Result;
                if (result.IsSuccessStatusCode)
                {
                    item.brand = result.Content.ReadAsAsync<BrandViewModel>().Result;
                }
                result = client.GetAsync("https://localhost:44309/api/category/" + item.CategoryId).Result;
                if (result.IsSuccessStatusCode)
                {
                    item.category = result.Content.ReadAsAsync<CategoryViewModel>().Result;
                }
            }
            var model = new ProductListViewModel()
            {
                Products = list
            };
            result = client.GetAsync("https://localhost:44309/api/brand").Result;
            if (result.IsSuccessStatusCode)
            {
                model.brands = result.Content.ReadAsAsync<List<BrandViewModel>>().Result;
            }
            result = client.GetAsync("https://localhost:44309/api/category").Result;
            if (result.IsSuccessStatusCode)
            {
                model.categories = result.Content.ReadAsAsync<List<CategoryViewModel>>().Result;
            }

            return View(model);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

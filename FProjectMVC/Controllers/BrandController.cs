using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FProjectMVC.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddB(CreateBrandViewModel createModel)
        {
            BrandViewModel brand = new BrandViewModel();
            HttpClient client = new HttpClient();
            var result = client.PostAsJsonAsync("https://localhost:44309/api/brand", createModel).Result;
            if (result.IsSuccessStatusCode)
            {
                brand = result.Content.ReadAsAsync<BrandViewModel>().Result;
            }
            return RedirectToAction("GetAllBrands");
        }

        public IActionResult GetAllBrands()
        {
            List<BrandViewModel> list = new List<BrandViewModel>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/brand").Result;
            if (result.IsSuccessStatusCode)
            {
                list = result.Content.ReadAsAsync<List<BrandViewModel>>().Result;
            }
            
            var model = new BrandListViewModel()
            {
                Brands = list
            };

            return View(model);
            //return View();
        }

        public IActionResult GetBrandById(long id)
        {
            BrandViewModel brand = new BrandViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/brand/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                brand = result.Content.ReadAsAsync<BrandViewModel>().Result;
            }

            return View(brand);
        }

        public IActionResult Update(long id)
        {
            BrandViewModel brand = new BrandViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/brand/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                brand = result.Content.ReadAsAsync<BrandViewModel>().Result;
            }
            return View(brand);
        }

        public IActionResult UpdateBrandS(BrandViewModel updateModel)
        {
            BrandViewModel brand = new BrandViewModel();
            HttpClient client = new HttpClient();
            var result = client.PutAsJsonAsync("https://localhost:44309/api/brand", updateModel).Result;
            if (result.IsSuccessStatusCode)
            {
                brand = result.Content.ReadAsAsync<BrandViewModel>().Result;
            }
            return RedirectToAction("GetBrandById", new { id = updateModel.Id });
        }

        public IActionResult Delete(long id)
        {
            BrandViewModel brand = new BrandViewModel();
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync("https://localhost:44309/api/brand/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                brand = result.Content.ReadAsAsync<BrandViewModel>().Result;
            }
            return RedirectToAction("GetAllBrands");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FProjectMVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddC(CreateCategoryViewModel createModel)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpClient client = new HttpClient();
            var result = client.PostAsJsonAsync("https://localhost:44309/api/category", createModel).Result;
            if (result.IsSuccessStatusCode)
            {
                category = result.Content.ReadAsAsync<CategoryViewModel>().Result;
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult GetAllCategories()
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/category").Result;
            if (result.IsSuccessStatusCode)
            {
                list = result.Content.ReadAsAsync<List<CategoryViewModel>>().Result;
            }

            var model = new CategoryListViewModel()
            {
                Categories = list
            };

            return View(model);
            //return View();
        }

        public IActionResult GetCategoryById(long id)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/category/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                category = result.Content.ReadAsAsync<CategoryViewModel>().Result;
            }

            return View(category);
        }

        public IActionResult Update(long id)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/category/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                category = result.Content.ReadAsAsync<CategoryViewModel>().Result;
            }
            return View(category);
        }

        public IActionResult UpdateCategoryS(CategoryViewModel updateModel)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpClient client = new HttpClient();
            var result = client.PutAsJsonAsync("https://localhost:44309/api/category", updateModel).Result;
            if (result.IsSuccessStatusCode)
            {
                category = result.Content.ReadAsAsync<CategoryViewModel>().Result;
            }
            return RedirectToAction("GetCategoryById", new { id = updateModel.Id });
        }

        public IActionResult Delete(long id)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync("https://localhost:44309/api/category/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                category = result.Content.ReadAsAsync<CategoryViewModel>().Result;
            }
            return RedirectToAction("GetAllCategories");
        }
    }
}

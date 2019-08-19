using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FProject.Domain;
using FProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> GetListByFilters(Params param = null)
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44309/api/product/filters", param);
            //var result = client.GetAsync("https://localhost:44309/api/product/filters",param).Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<ProductViewModel>>().Result;
            }
            foreach (var item in list)
            {
                response = client.GetAsync("https://localhost:44309/api/brand/" + item.BrandId).Result;
                if (response.IsSuccessStatusCode)
                {
                    item.brand = response.Content.ReadAsAsync<BrandViewModel>().Result;
                }
                response = client.GetAsync("https://localhost:44309/api/category/" + item.CategoryId).Result;
                if (response.IsSuccessStatusCode)
                {
                    item.category = response.Content.ReadAsAsync<CategoryViewModel>().Result;
                }
            }
            var model = new ProductListViewModel()
            {
                Products = list
            };
            response = client.GetAsync("https://localhost:44309/api/brand").Result;
            if (response.IsSuccessStatusCode)
            {
                model.brands = response.Content.ReadAsAsync<List<BrandViewModel>>().Result;
            }
            response = client.GetAsync("https://localhost:44309/api/category").Result;
            if (response.IsSuccessStatusCode)
            {
                model.categories = response.Content.ReadAsAsync<List<CategoryViewModel>>().Result;
            }


            return View(model);
            //return View();
        }

        public IActionResult GetProductById(long id)
        {
            ProductViewModel product = new ProductViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/product/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                product = result.Content.ReadAsAsync<ProductViewModel>().Result;
            }

            result = client.GetAsync("https://localhost:44309/api/brand/" + product.BrandId).Result;
            if (result.IsSuccessStatusCode)
            {
                product.brand = result.Content.ReadAsAsync<BrandViewModel>().Result;
            }

            result = client.GetAsync("https://localhost:44309/api/category/" + product.CategoryId).Result;
            if (result.IsSuccessStatusCode)
            {
                product.category = result.Content.ReadAsAsync<CategoryViewModel>().Result;
            }
            return View(product);
        }

        public IActionResult Add()
        {
            CreateProductViewModel model = new CreateProductViewModel();HttpClient client = new HttpClient();
            var brands = new List<BrandViewModel>();
            var result = client.GetAsync("https://localhost:44309/api/brand").Result;
            if (result.IsSuccessStatusCode)
            {
                brands = result.Content.ReadAsAsync<List<BrandViewModel>>().Result;
            }
            var categories = new List<CategoryViewModel>();
            
             result = client.GetAsync("https://localhost:44309/api/category").Result;
            if (result.IsSuccessStatusCode)
            {
                categories = result.Content.ReadAsAsync<List<CategoryViewModel>>().Result;
            }

            model.brands = new SelectList(brands
                .Select(x =>
                new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                }), "Value", "Text");

            model.categories = new SelectList(categories
                .Select(x =>
                new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                }), "Value", "Text");

            return View(model);
        }
        public IActionResult AddP(CreateProductViewModel createModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpClient client = new HttpClient();
            var result = client.PostAsJsonAsync("https://localhost:44309/api/product", createModel).Result;
            if (result.IsSuccessStatusCode)
            {
                product = result.Content.ReadAsAsync<ProductViewModel>().Result;
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult Update(long id)
        {
            UpdateProductViewModel product = new UpdateProductViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/product/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                product = result.Content.ReadAsAsync<UpdateProductViewModel>().Result;
            }
            var brands = new List<BrandViewModel>();
            result = client.GetAsync("https://localhost:44309/api/brand").Result;
            if (result.IsSuccessStatusCode)
            {
                 brands = result.Content.ReadAsAsync<List<BrandViewModel>>().Result;
            }
            var categories = new List<CategoryViewModel>();
            result = client.GetAsync("https://localhost:44309/api/category").Result;
            if (result.IsSuccessStatusCode)
            {
                categories = result.Content.ReadAsAsync<List<CategoryViewModel>>().Result;
            }

            product.brands = new SelectList(brands
                .Select(x =>
                new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                }), "Value", "Text");

            product.categories = new SelectList(categories
                .Select(x =>
                new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                }), "Value", "Text");

            return View(product);
        }

        public IActionResult UpdateProductS(UpdateProductViewModel updateModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpClient client = new HttpClient();
            var result = client.PutAsJsonAsync("https://localhost:44309/api/product", updateModel).Result;
            if (result.IsSuccessStatusCode)
            {
                product = result.Content.ReadAsAsync<ProductViewModel>().Result;
            }
            return RedirectToAction("GetProductById", new {id= updateModel.Id });
        }

        public IActionResult Delete(long id)
        {
            ProductViewModel product = new ProductViewModel();
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync("https://localhost:44309/api/product/"+ id).Result;
            if (result.IsSuccessStatusCode)
            {
                product = result.Content.ReadAsAsync<ProductViewModel>().Result;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
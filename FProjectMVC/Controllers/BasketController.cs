using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FProjectMVC.Mapping;
using FProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FProjectMVC.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Add(long productId, long userId = 1)
        {
            CreateBasketItemViewModel model = new CreateBasketItemViewModel();
            model.ProductId = productId;
            model.BasketId = userId;
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/product/" + productId).Result;
            if (result.IsSuccessStatusCode)
            {
                model.product = result.Content.ReadAsAsync<ProductViewModel>().Result;
            }
            return View(model);
        }
        public IActionResult AddItem(CreateBasketItemViewModel item, long userId=1)
        {
            if (item.Quantity < 1) return BadRequest($"{nameof(item.Quantity)} <= 0");
            BasketItemViewModel bItem = new BasketItemViewModel();
            HttpClient client = new HttpClient();
            var result = client.PostAsJsonAsync("https://localhost:44309/api/basket/"+userId, item).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("GetProductById","Product",new { id= item.ProductId });
            }

            return RedirectToAction("Add",new { productId=item.ProductId });
        }

        public IActionResult Index()
        {
            BasketViewModel basket = new BasketViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/basket/1").Result;
            if (result.IsSuccessStatusCode)
            {
                basket = result.Content.ReadAsAsync<BasketViewModel>().Result;
            }
            basket.items = BasketToViewModel.Convert(basket.BasketItems);
            foreach (var item in basket.items)
            {
                result = client.GetAsync("https://localhost:44309/api/product/" + item.ProductId).Result;
                if (result.IsSuccessStatusCode)
                {
                    item.product = result.Content.ReadAsAsync<ProductViewModel>().Result;
                }
            }
            return View(basket);
        }

        public IActionResult Delete(BasketItemViewModel item,long userId=1)
        {
            
            HttpClient client = new HttpClient();
            
            var result = client.PutAsJsonAsync("https://localhost:44309/api/basket/" + userId,item).Result;
            if (result.IsSuccessStatusCode)
            {
                Ok(); 
            }
            return RedirectToAction("Index");
        }

    }
}
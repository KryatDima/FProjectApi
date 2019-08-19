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
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrderById(long id)
        {
            OrderViewModel order = new OrderViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/order/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                order = result.Content.ReadAsAsync<OrderViewModel>().Result;
            }

            return View(order);
        }

        public IActionResult Create()
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
            CreateOrderViewModel order = new CreateOrderViewModel()
            {
                User = basket.User,
                items = BasketToCreateOrder.Convert(basket.items),
                TotalPrice= basket.items.Select(p => p.product.Price).Sum(),
                
            };
            
            

            return View(order);
        }
        public IActionResult AddO(CreateOrderViewModel vm)
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
            CreateOrderViewModel order = new CreateOrderViewModel()
            {
                User = basket.User,
                items = BasketToCreateOrder.Convert(basket.items),
                TotalPrice = basket.items.Select(p => p.product.Price).Sum(),
                Comment=vm.Comment
            };
            
            order.OrderItems = BasketToCreateOrder.Convert(order.items);
            OrderViewModel model = new OrderViewModel();
            
            result = client.PostAsJsonAsync("https://localhost:44309/api/order", order).Result;
            if (result.IsSuccessStatusCode)
            {
                model= result.Content.ReadAsAsync<OrderViewModel>().Result;
            }
            return RedirectToAction("GetOrderById", new { id=model.Id });
        }
    }
}
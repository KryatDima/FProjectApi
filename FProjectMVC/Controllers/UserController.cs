using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FProjectMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Registration(RegisterViewModel createModel)
        {
            UserViewModel brand = new UserViewModel();
            HttpClient client = new HttpClient();
            var result = client.PostAsJsonAsync("https://localhost:44309/api/user", createModel).Result;
            if (result.IsSuccessStatusCode)
            {
                brand = result.Content.ReadAsAsync<UserViewModel>().Result;
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult Update(long userId=1)
        {
            UpdateUserViewModel user = new UpdateUserViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/user/" + userId).Result;
            if (result.IsSuccessStatusCode)
            {
                user = result.Content.ReadAsAsync<UpdateUserViewModel>().Result;
            }
            return View(user);
        }

        public IActionResult UpdateUser(UpdateUserViewModel updateModel)
        {
            UserViewModel user = new UserViewModel();
            HttpClient client = new HttpClient();
            var result = client.PutAsJsonAsync("https://localhost:44309/api/user", updateModel).Result;
            if (result.IsSuccessStatusCode)
            {
                user = result.Content.ReadAsAsync<UserViewModel>().Result;
            }
            return RedirectToAction("GetUserById", new { id = updateModel.Id });
        }

        public IActionResult Delete(long userId)
        {
            UserViewModel user = new UserViewModel();
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync("https://localhost:44309/api/user/" + userId).Result;
            if (result.IsSuccessStatusCode)
            {
                user = result.Content.ReadAsAsync<UserViewModel>().Result;
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetUserById(long userId=1)
        {
            UserViewModel user = new UserViewModel();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44309/api/user/" + userId).Result;
            if (result.IsSuccessStatusCode)
            {
                user = result.Content.ReadAsAsync<UserViewModel>().Result;
            }
            return View(user);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(long id)
        //{
        //    if (await service.Delete(id))
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(long id)
        //{
        //    var dto = await service.Get(id);
        //    if (dto != null)
        //    {
        //        return Ok(dto);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}
    }
}
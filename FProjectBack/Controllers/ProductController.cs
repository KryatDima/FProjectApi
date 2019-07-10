using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FProject.Domain.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FProjectBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(long id)
        {
            var entity = await service.Get(id);
            return Ok(entity);
        }

        [HttpGet("search/{searchQuery?}")]
        public async Task<IActionResult> GetListBySearchQuery(string searchQuery)
        {
            if (searchQuery == null || searchQuery.Length <= 4)
                return Ok();

            //var userId = GetUserId();
            var entity = await service.GetListBySearchQuery(searchQuery);

            if (!entity.Any())
            {
                //var title= await service
                entity = await service.GetListBySearchQuery(searchQuery);

                return Ok();
            }
            return Ok();
        }
    }
}
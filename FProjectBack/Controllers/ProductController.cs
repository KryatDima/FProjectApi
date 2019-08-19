using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FProject.Contracts;
using FProject.Domain;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var dto= await service.Get(id);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var dto = await service.GetProducts();
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return NoContent();
            }
        }

        //[HttpGet("search/{searchQuery?}")]
        //public async Task<IActionResult> GetListBySearchQuery(string searchQuery)
        //{
        //    if (searchQuery == null || searchQuery.Length <= 4)
        //        return Ok();

        //    //var userId = GetUserId();
        //    var entity = await service.GetListBySearchQuery(searchQuery);

        //    if (!entity.Any())
        //    {
        //        //var title= await service
        //        entity = await service.GetListBySearchQuery(searchQuery);

        //        return Ok();
        //    }
        //    return Ok();
        //}

        [HttpPost("filters")]
        public async Task<IActionResult> GetListByFilters(Params param=null)
        {
            var dtos = await service.GetListByFilters(param);
            if (dtos != null)
            {
                return Ok(dtos);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("search/{searchQuery?}")]
        public async Task<IActionResult> GetListBySearchQuery(string searchQuery)
        {
            var dtos = await service.GetListBySearchQuery(searchQuery);
            if (dtos != null)
            {
                return Ok(dtos);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDTO createDto)
        {
            var productDto = await service.Add(createDto);
            if (productDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(productDto)} is null");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDTO dto)
        {
            var productDto = await service.Update(dto);
            if (productDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(productDto)} is null");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (await service.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
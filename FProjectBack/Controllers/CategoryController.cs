using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FProject.Contracts;
using FProject.Domain.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FProjectBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDTO createDto)
        {
            var categoryDto = await service.Add(createDto);
            if (categoryDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(categoryDto)} is null");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO dto)
        {
            var categoryDto = await service.Update(dto);
            if (categoryDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(categoryDto)} is null");
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var dto = await service.Get(id);
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
        public async Task<IActionResult> GetAll()
        {
            var dto = await service.GetAll();
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
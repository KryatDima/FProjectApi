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
    public class BasketController : ControllerBase
    {
        private readonly IBasketService service;

        public BasketController(IBasketService service)
        {
            this.service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(long userId)
        {
            var dto =await service.GetBasketByUserId(userId);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddItem(CreateBasketItemsDTO item, long userId)
        {
            var dto = await service.AddItem(item, userId);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> DeleteItem(BasketItemsDTO entity, long userId)
        {
            var dto = await service.Delete(entity, userId);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{userId}/all")]
        public async Task<IActionResult> DeleteAllItems(long userId)
        {
            var dto = await service.DeleteAllItems( userId);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
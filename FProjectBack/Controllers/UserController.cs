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
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterModelDTO createDto)
        {
            var userDto = await service.CreateAsync(createDto);
            if (userDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(userDto)} is null");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDTO dto)
        {
            var brandDto = await service.Update(dto);
            if (brandDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(brandDto)} is null");
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
    }
}
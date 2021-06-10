using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTask.DTO;
using BookTask.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookTask.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ManageController : ControllerBase
    {
        private readonly IBookManageService _bookManageService;
        public ManageController(IBookManageService bookManageService)
        {
            _bookManageService = bookManageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _bookManageService.GetByIdAsync(id);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto bookDto)
        {
            if (string.IsNullOrEmpty(bookDto.Title)
                || string.IsNullOrEmpty(bookDto.Description))
            {
                return BadRequest();
            }

            var result = await _bookManageService.CreateAsync(bookDto.Id, bookDto.Title, bookDto.Description);
            return result != 0 ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BookDto bookDto)
        {
            if (bookDto.Id == 0)
            {
                return BadRequest();
            }

            var result = await _bookManageService.UpdateAsync((int)bookDto.Id, bookDto.Title, bookDto.Description);
            return result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BookDto bookDto)
        {
            if (bookDto.Id == 0)
            {
                return BadRequest();
            }

            var result = await _bookManageService.DeleteAsync((int)bookDto.Id);
            return result ? Ok(result) : BadRequest(result);
        }
    }
}

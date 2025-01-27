using EcommerceApp.Application.DTOs.Category;
using EcommerceApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryControllerr(ICategoryService categorytService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await categorytService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var product = await categorytService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCategory product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await categorytService.AddAsync(product);
            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategory product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await categorytService.UpdateAsync(product);
            if (response.IsSuccess)
                return NoContent();
            else
                return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await categorytService.DeleteAsync(id);
            if (response.IsSuccess)
                return NoContent();
            else
                return NotFound(response.Message);
        }
    }
}

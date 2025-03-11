using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.DTOs.Product;
using EcommerceApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService,ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var product = await productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] CreateProduct product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await productService.AddAsync(product);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProduct product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await productService.UpdateAsync(product);
            if (response.IsSuccess)
                return NoContent();
            else
                return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await productService.DeleteAsync(id);
            if (response.IsSuccess)
                return NoContent();
            else
                return NotFound(response.Message);
        }

        [HttpGet("productsByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
        {

            var products = await categoryService.GetProductsByCategory(categoryId);
            
            return products.Any() ? Ok(products) : NotFound();
        }
    }
}
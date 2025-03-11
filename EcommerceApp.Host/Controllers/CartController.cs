using EcommerceApp.Application.Services.Interfaces.Cart;
using EcommerceApp.Domain.Entities.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CartController (ICartService cartService): ControllerBase
{
    [HttpPost("checkout")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> CheckOut( CheckOut checkOut)
    {
        if(!ModelState.IsValid)
           return BadRequest(ModelState); 
        
        var result = await cartService.CheckOutAsync(checkOut);
        
        if (result.IsSuccess)
           return Ok(result);
        
        return BadRequest(result);
    }
    [HttpPost("saveCheckOutHistory")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> SaveCheckOutHistory(IEnumerable<CreateCartItem> checkOuts)
    {
        if(!ModelState.IsValid)
           return BadRequest(ModelState); 
        
        var result = await cartService.SaveCheckOutHistoryAsync(checkOuts);
        
        if (result.IsSuccess)
           return Ok(result);
        
        return BadRequest(result);
    }
}
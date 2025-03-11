using EcommerceApp.Application.Services.Interfaces.Cart;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController(IPaymentMethodService paymentMethodService) : ControllerBase
{
    [HttpGet("Payment-Methods")]
    public async Task<IActionResult> GetPaymentMethods( )
    {
        var paymentMethods = await paymentMethodService.GetPaymentMethodsAsync();
        if (!paymentMethods.Any())
            return NotFound();
        return Ok(paymentMethods);
    }
}
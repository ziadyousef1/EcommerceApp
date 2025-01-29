using EcommerceApp.Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EcommerceApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeetingsController(IOptions<JwtSettings> options) : ControllerBase
    {
        private readonly JwtSettings _jwtSettings = options.Value;

        [HttpGet]
        public async Task<IActionResult> getsettings()
        {
            return Ok(_jwtSettings.Issuer);
        }
    }
}

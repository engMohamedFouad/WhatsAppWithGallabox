using Microsoft.AspNetCore.Mvc;
using WhatsAppWithGallabox.Services;

namespace WhatsAppWithGallabox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly IWhatsAppService _whatsAppService;
        public WhatsAppController(IWhatsAppService whatsAppService)
        {
            _whatsAppService = whatsAppService;
        }
        [HttpPost]
        public async Task<IActionResult> SendTempleteMessage(string Phone, string customerName)
        {
            var result = await _whatsAppService.SendTempleteWiothVariablesAsync(Phone, customerName);
            if (result=="success") return Ok("Send Successfully");
            return BadRequest(result);
        }
    }
}

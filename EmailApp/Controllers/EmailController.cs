using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            Message message = new(new string[] { "cesar5@ethereal.email" }, "Test Mail",
                                  "This is a test mail using attachment", files);
            await _emailSender.SendEmailAsync(message);
            return Ok();
        }
    }
}

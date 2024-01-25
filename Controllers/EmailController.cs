using BookAPI.Repositories.IEService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookAPI.Models.DTOs.DTOs;

namespace BookAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase {

        private readonly IEmailInterface emailService;

        public EmailController(IEmailInterface emailService) {
            this.emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO request) {

            emailService.SendEmail(request);
            return StatusCode(200, "Levél elküldve!");
        }
    }
}

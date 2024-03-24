using MailSender_Domain.Interfaces.Services;
using MailSender_Domain.Extensions.ResultExtentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailSender_Domain.Entities;

namespace MailSender_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailSenderController : ControllerBase
    {
        private readonly IMailSenderService _mailSenderService;
        public MailSenderController(IMailSenderService mailSenderService)
        {
            _mailSenderService = mailSenderService;
        }

        [HttpGet("PingApi")]
        public IActionResult PingApi() => Ok(ControllerContext.RouteData.Values["controller"] + " - " + "RUNNING" + " - " + DateTime.Now);

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Parameters modelData)
        {
            var result = await _mailSenderService.SendMail(modelData);
            return this.FromResult(result);
        }
                
    }
}

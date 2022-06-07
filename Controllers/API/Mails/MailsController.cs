using EggStore.Domains.Mails.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Coravel.Queuing.Interfaces;
using EggStore.Infrastucture.Helpers.ResponseBuilders;

namespace EggStore.Controllers.API.Mails
{
    [Route("api/mails")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        IEmailSender _emailSender;
        private IQueue _queue;
        public MailsController(IEmailSender emailSender, IQueue queue)
        {
            _emailSender = emailSender;
            _queue = queue;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmailAsync(string recipientEmail, string recipientFirstName, string Link)
        {
            try
            {
                _queue.QueueTask(() =>
                {
                    _emailSender.SendEmailAsync(recipientEmail, recipientFirstName, Link);
                });

                return Ok(ResponseBuilder.SuccessResponse("Success sending email", null));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}

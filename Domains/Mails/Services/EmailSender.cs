using EggStore.Domains.Mails.Interface;
using EggStore.Domains.Mails.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;

namespace EggStore.Domains.Mails.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;
        public EmailSender(IOptions<EmailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration.Value;
        }
        public async Task<string> SendEmailAsync(string recipientEmail, string recipientFirstName, string Link)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_emailConfiguration.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "How to send email in .Net Core";
            message.Body = new TextPart("plain")
            {
                Text = "This is just a walkthrough in sending messages in .net core"
            };

            var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(_emailConfiguration.Server, _emailConfiguration.Port, true);
                await client.AuthenticateAsync(new NetworkCredential(_emailConfiguration.SenderEmail, _emailConfiguration.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}

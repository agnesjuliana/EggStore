namespace EggStore.Domains.Mails.Interface
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(string recipientEmail, string recipientFirstName, string Link);
    }
}

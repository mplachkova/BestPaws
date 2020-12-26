namespace BestPaws.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class SendGridMailService : ISendGridMailService
    {
        private IConfiguration configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = this.configuration["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("bestpaws@abv.bg", "Best Paws");
            var to = new EmailAddress("bestpaws@abv.bg", "Best Paws");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}

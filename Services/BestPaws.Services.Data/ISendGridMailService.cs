namespace BestPaws.Services.Data
{
    using System.Threading.Tasks;

    public interface ISendGridMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}

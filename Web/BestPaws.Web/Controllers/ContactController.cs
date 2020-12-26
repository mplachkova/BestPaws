namespace BestPaws.Web.Controllers
{
    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels.Contact;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
        private readonly ISendGridMailService mailService;

        public ContactController(ISendGridMailService mailService)
        {
            this.mailService = mailService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(MessageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            this.mailService.SendEmailAsync(input.AuthorEmail, input.Subject, input.Content);
            this.TempData["Message"] = "Your message was sent! We will contact you shortly.";
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}

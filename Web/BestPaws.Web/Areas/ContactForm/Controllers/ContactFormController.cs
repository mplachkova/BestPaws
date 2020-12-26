namespace BestPaws.Web.Areas.ContactForm.Controllers
{
    using BestPaws.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    public class ContactFormController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

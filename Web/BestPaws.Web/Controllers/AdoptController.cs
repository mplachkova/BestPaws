namespace BestPaws.Web.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    public class AdoptController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

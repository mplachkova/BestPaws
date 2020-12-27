namespace BestPaws.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using BestPaws.Common;
    using BestPaws.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : BaseController
    {
        [Route("/Error/500")]
        public IActionResult InternalServerError()
        {
            var errorModel = new ErrorViewModel
            {
                StatusCode = GlobalConstants.InternalServerError,
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier,
            };

            return this.View(errorModel);
        }

        public IActionResult NotFoundError()
        {
            var errorViewModel = new ErrorViewModel();
            errorViewModel.StatusCode = GlobalConstants.NotFound;

            if (this.TempData["ErrorParams"] is Dictionary<string, string> dict)
            {
                errorViewModel.RequestId = dict["RequestId"];
                errorViewModel.RequestPath = dict["RequestPath"];
            }

            if (errorViewModel.RequestId == null)
            {
                errorViewModel.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
            }

            return this.View(errorViewModel);
        }
    }
}

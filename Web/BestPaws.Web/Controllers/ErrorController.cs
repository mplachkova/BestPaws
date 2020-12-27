namespace BestPaws.Web.Controllers
{
    using BestPaws.Common;
    using BestPaws.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : BaseController
    {
        [Route("/Error/500")]
        public IActionResult InternalServerError()
        {
            var errorModel = new ErrorViewModel();
            errorModel.StatusCode = GlobalConstants.NotFound;
            return this.View(errorModel);
        }

        public IActionResult NotFoundError()
        {
            var errorViewModel = new ErrorViewModel();
            errorViewModel.StatusCode = GlobalConstants.NotFound;
            return this.View(errorViewModel);
        }
    }
}

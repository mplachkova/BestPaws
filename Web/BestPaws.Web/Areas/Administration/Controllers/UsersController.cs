namespace BestPaws.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdministrationController
    {
        private readonly IUserService userService;

        public UsersController(IUserService service)
        {
            this.userService = service;
        }

        public IActionResult AddAdmin()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(UserInputModel input)
        {
            if (input == null)
            {
                return this.RedirectToAction("NotFoundError", "Error");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.userService.CreateAdminAsync(input);

            this.TempData["Message"] = "Admin was registered successfully";
            return this.RedirectToAction(nameof(this.AddAdmin));
        }
    }
}

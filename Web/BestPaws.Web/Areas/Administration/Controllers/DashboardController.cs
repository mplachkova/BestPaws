namespace BestPaws.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels.Services;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IServicesService service;

        public DashboardController(IServicesService service)
        {
            this.service = service;
        }

        // For Admin to Add new petService offered by the clinic
        public IActionResult AddService()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(ServiceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.service.CreateAsync(input);
            this.TempData["Message"] = "Service was added successfully";
            return this.RedirectToAction(nameof(this.ManageServices));
        }

        // For Admin to Edit ot Delete/Restore Service
        public IActionResult ManageServices()
        {
            var services = this.service.GetAllWithDeleted();
            var inputModel = new ServiceListViewModel { Services = services };
            return this.View(inputModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteAsync(id);
            this.TempData["Message"] = "Service was deleted successfully";
            return this.RedirectToAction(nameof(this.ManageServices));
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.service.GetServiceById(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.service.EditAsync(id, input);
            var viewModel = this.service.GetServiceById(id);
            this.TempData["Message"] = "Service was edited successfully";
            return this.RedirectToAction(nameof(this.ManageServices));
        }

        public async Task<IActionResult> Restore(int id)
        {
            await this.service.RestoreAsync(id);
            this.TempData["Message"] = "Service was restored successfully";
            return this.RedirectToAction(nameof(this.ManageServices));
        }
    }
}

namespace BestPaws.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;
    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels;
    using BestPaws.Web.ViewModels.Doctor;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class DoctorsController : AdministrationController
    {
        private readonly IDoctorService doctorService;

        public DoctorsController(IDoctorService service)
        {
            this.doctorService = service;
        }

        // GET: Administration/Doctors
        public IActionResult Index()
        {
            var doctorsList = this.doctorService.GetAll<DoctorViewModel>();
            var viewModel = new DoctorListViewModel { Doctors = doctorsList };
            return this.View(viewModel);
        }

        // GET: Administration/Doctors/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var doctor = this.doctorService.GetDoctorById(id);
            return this.View(doctor);
        }

        // GET: Administration/Doctors/Create
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.doctorService.AddDoctor(inputModel);

            this.TempData["Message"] = "Doctor was registered successfully";
            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Doctors/Edit/5
        public IActionResult Edit(string id)
        {
            var viewModel = this.doctorService.GetDoctorById(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DoctorInputModel model)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.doctorService.EditAsync(id, model);
            var viewModel = this.doctorService.GetDoctorById(id);
            this.TempData["Message"] = "Doctor was edited successfully";
            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Doctors/Delete/5
        public IActionResult Delete(string id)
        {
            var viewModel = this.doctorService.GetDoctorById(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, DoctorInputModel model)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.doctorService.DeleteAsync(id);
            this.TempData["Message"] = "Doctor was deleted successfully";
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Restore(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            await this.doctorService.RestoreAsync(id);
            this.TempData["Message"] = "Doctor was restored successfully";
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}

namespace BestPaws.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels.Doctor;
    using Microsoft.AspNetCore.Mvc;

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
            var doctorsList = this.doctorService.GetAllWithDeleted<DoctorViewModel>();
            var viewModel = new DoctorListViewModel { Doctors = doctorsList };
            if (viewModel == null)
            {
                return this.RedirectToAction("NotFoundError", "Error");
            }

            return this.View(viewModel);
        }

        // GET: Administration/Doctors/Details/5
        public IActionResult Details(string id)
        {
            var doctor = this.doctorService.GetDoctorById(id);
            return this.View(doctor);
        }

        // GET: Administration/Doctors/Create
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            if (id == null || model == null)
            {
                return this.RedirectToAction("NotFoundError", "Error");
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
            if (id == null || model == null)
            {
                return this.RedirectToAction("NotFoundError", "Error");
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
                return this.RedirectToAction("NotFoundError", "Error");
            }

            await this.doctorService.RestoreAsync(id);
            this.TempData["Message"] = "Doctor was restored successfully";
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}

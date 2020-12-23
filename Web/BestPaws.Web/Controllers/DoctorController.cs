namespace BestPaws.Web.Controllers
{
    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels.Doctor;
    using Microsoft.AspNetCore.Mvc;

    public class DoctorController : BaseController
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService service)
        {
            this.doctorService = service;
        }

        public IActionResult Index()
        {
            var doctors = this.doctorService.GetAll<DoctorViewModel>();
            var model = new DoctorListViewModel { Doctors = doctors };
            return this.View(model);
        }
    }
}

namespace BestPaws.Web.Controllers
{
    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels.Treatments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TreatmentsController : BaseController
    {
        private readonly ITreatmentsService treatmentService;
        private readonly IPetCenterService petCenterService;

        public TreatmentsController(
            ITreatmentsService service,
            IPetCenterService petCenterService)
        {
            this.treatmentService = service;
            this.petCenterService = petCenterService;
        }

        [Authorize]
        public IActionResult Index(int id)
        {
            var treatmentsList = this.treatmentService.GetAll<TreatmentViewModel>(id);
            var model = new TreatmentListViewModel { Treatments = treatmentsList };
            model.PetName = this.petCenterService.GetPetName(id);
            model.PetId = id;
            return this.View(model);
        }
    }
}

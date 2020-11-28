namespace BestPaws.Web.Controllers
{
    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels;
    using BestPaws.Web.ViewModels.PetCenter;
    using Microsoft.AspNetCore.Mvc;

    public class PetCenterController : BaseController
    {
        private readonly IDeletableEntityRepository<Pet> repository;
        private readonly IPetCenterService service;

        public PetCenterController(IPetCenterService petService, IDeletableEntityRepository<Pet> petRepository)
        {
            this.repository = petRepository;
            this.service = petService;
        }

        public IActionResult Index()
        {
            var pets = this.service.GetAll<PetCenterViewModel>();
            var model = new PetCenterListViewModel { Pets = pets };
            return this.View(model);
        }
    }
}

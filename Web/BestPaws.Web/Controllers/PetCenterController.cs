namespace BestPaws.Web.Controllers
{
    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels;
    using BestPaws.Web.ViewModels.PetCenter;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class PetCenterController : BaseController
    {
        private readonly IPetCenterService service;
        private readonly IAnimalTypeService animalTypeSevice;
        private readonly IAddPetService addPetService;

        public PetCenterController(
            IPetCenterService petService,
            IAnimalTypeService animalTypeService,
            IAddPetService addPetService)
        {
            this.service = petService;
            this.animalTypeSevice = animalTypeService;
            this.addPetService = addPetService;
        }

        public IActionResult Index()
        {
            var pets = this.service.GetAll<PetCenterViewModel>();
            var model = new PetCenterListViewModel { Pets = pets };
            return this.View(model);
        }

        public IActionResult AddPet()
        {
            var model = new AddPetInputModel();
            model.AnimalTypes = this.animalTypeSevice.GetAllAnimalTypes();
            return this.View(model);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> AddPet(AddPetInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.AnimalTypes = this.animalTypeSevice.GetAllAnimalTypes();
                return this.View(input);
            }

            await this.addPetService.CreateAsync(input);
            return this.Redirect("/PetCenter");
        }
    }
}

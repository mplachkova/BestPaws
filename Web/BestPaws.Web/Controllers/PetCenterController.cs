namespace BestPaws.Web.Controllers
{
    using System.Threading.Tasks;

    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels;
    using BestPaws.Web.ViewModels.PetCenter;
    using Microsoft.AspNetCore.Mvc;

    public class PetCenterController : BaseController
    {
        private readonly IPetCenterService service;
        private readonly IAnimalTypeService animalTypeSevice;
        private readonly IAddPetService addPetService;
        private readonly IAnimalBreedService breedService;

        public PetCenterController(
            IPetCenterService petService,
            IAnimalTypeService animalTypeService,
            IAddPetService addPetService,
            IAnimalBreedService breedService)
        {
            this.service = petService;
            this.animalTypeSevice = animalTypeService;
            this.addPetService = addPetService;
            this.breedService = breedService;
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
            model.AnimalBreeds = this.breedService.GetAllAnimalBreeds();
            return this.View(model);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> AddPet(AddPetInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.AnimalTypes = this.animalTypeSevice.GetAllAnimalTypes();
                input.AnimalBreeds = this.breedService.GetAllAnimalBreeds();
                return this.View(input);
            }

            await this.addPetService.CreateAsync(input);
            return this.Redirect("/PetCenter");
        }
    }
}

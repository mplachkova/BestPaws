namespace BestPaws.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using BestPaws.Services.Data;
    using BestPaws.Web.ViewModels;
    using BestPaws.Web.ViewModels.PetCenter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PetCenterController : BaseController
    {
        private readonly IPetCenterService petService;
        private readonly IAnimalTypeService animalTypeSevice;
        private readonly IAnimalBreedService breedService;
        private readonly IDoctorService doctorService;

        public PetCenterController(
            IPetCenterService petService,
            IAnimalTypeService animalTypeService,
            IAnimalBreedService breedService,
            IDoctorService doctorService)
        {
            this.petService = petService;
            this.animalTypeSevice = animalTypeService;
            this.breedService = breedService;
            this.doctorService = doctorService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var pets = this.petService.GetAllForCurrentUser<PetCenterViewModel>(userId);
            var model = new PetCenterListViewModel { Pets = pets };
            return this.View(model);
        }

        [Authorize(Roles = "Doctor, Administrator")]
        public IActionResult RegisterPet()
        {
            var model = new AddPetInputModel();
            model.AnimalTypes = this.animalTypeSevice.GetAllAnimalTypes();
            model.AnimalBreeds = this.breedService.GetAllAnimalBreeds();
            model.Doctors = this.doctorService.GetAllDoctorsFirstAndLastName();
            return this.View(model);
        }

        [Authorize(Roles = "Doctor, Administrator")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> RegisterPet(AddPetInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.AnimalTypes = this.animalTypeSevice.GetAllAnimalTypes();
                input.AnimalBreeds = this.breedService.GetAllAnimalBreeds();
                input.Doctors = this.doctorService.GetAllDoctorsFirstAndLastName();
                return this.View(input);
            }

            await this.petService.CreateAsync(input);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}

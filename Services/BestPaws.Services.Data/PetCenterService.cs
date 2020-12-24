namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;
    using BestPaws.Web.ViewModels.PetCenter;

    public class PetCenterService : IPetCenterService
    {
        private readonly IDeletableEntityRepository<Pet> petRepository;
        private readonly IUserService userService;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<PetOwner> ownerRepository;

        public PetCenterService(
            IDeletableEntityRepository<Pet> petRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<PetOwner> ownerRepository,
            IUserService service)
        {
            this.petRepository = petRepository;
            this.userService = service;
            this.userRepository = userRepository;
            this.ownerRepository = ownerRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var result = this.petRepository.All().To<T>().ToList();
            return result;
        }

        public IEnumerable<T> GetAllForCurrentUser<T>(string id)
        {
            var currentAppOwner = this.userRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            var currentPetowner = this.ownerRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.ApplicationUser == currentAppOwner);

            var result = this.petRepository
                .All()
                .Where(x => x.PetOwner == currentPetowner)
                .To<T>()
                .ToList();
            return result;
        }

        public async Task CreateAsync(AddPetInputModel input)
        {
            await this.userService.CreateUserAsync(input);
            var currentAppUser = this.userRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.UserName == input.EmailAddress);

            var pet = new Pet
            {
                AnimalTypeId = input.AnimalTypeId,
                AnimalBreedId = input.AnimalBreedId,
                Age = input.Age,
                Name = input.Name,
                Gender = input.Gender,
                DoctorId = input.DoctorId,
            };

            var currentPetOwner = this.ownerRepository
                .All()
                .FirstOrDefault(x => x.ApplicationUser == currentAppUser);
            await this.petRepository.AddAsync(pet);
            await this.petRepository.SaveChangesAsync();
            currentPetOwner.Pets.Add(pet);
            await this.ownerRepository.SaveChangesAsync();
        }
    }
}

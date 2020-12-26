namespace BestPaws.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BestPaws.Common;
    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;
    using BestPaws.Web.ViewModels.PetCenter;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class PetCenterService : IPetCenterService
    {
        private readonly IDeletableEntityRepository<Pet> petRepository;
        private readonly IUserService userService;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<PetOwner> ownerRepository;
        private readonly IServiceProvider serviceProvider;
        private readonly IDeletableEntityRepository<Doctor> doctorRepository;

        public PetCenterService(
            IDeletableEntityRepository<Pet> petRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<PetOwner> ownerRepository,
            IDeletableEntityRepository<Doctor> doctorReposiory,
            IUserService userService,
            IServiceProvider serviceProvider)
        {
            this.petRepository = petRepository;
            this.userService = userService;
            this.userRepository = userRepository;
            this.ownerRepository = ownerRepository;
            this.serviceProvider = serviceProvider;
            this.doctorRepository = doctorReposiory;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var result = this.petRepository.All().To<T>().ToList();
            return result;
        }

        public IEnumerable<T> GetAllForCurrentUser<T>(string id)
        {
            var currentAppUser = this.userRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            var userManager = this.serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userRoles = userManager.GetRolesAsync(currentAppUser).Result;

            List<T> result;

            if (userRoles.Contains(GlobalConstants.PetOwnerRoleName))
            {
                result = this.petRepository
                    .All()
                    .Where(x => x.PetOwner.ApplicationUserId == currentAppUser.Id)
                    .To<T>()
                    .ToList();
            }
            else if (userRoles.Contains(GlobalConstants.DoctorRoleName))
            {
                result = this.petRepository
                    .All()
                    .Where(x => x.Doctor.ApplicationUserId == currentAppUser.Id)
                    .To<T>()
                    .ToList();
            }
            else
            {
                result = this.petRepository
                    .All()
                    .To<T>()
                    .ToList();
            }

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

            var currentDoctor = this.doctorRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Id == input.DoctorId);
            currentDoctor.Pets.Add(pet);
            await this.doctorRepository.SaveChangesAsync();
        }

        public PetCenterViewMode GellAllPetInfo(int id)
        {
            var currentPet = this.petRepository
                .AllAsNoTracking()
                .To<PetCenterViewMode>()
                .FirstOrDefault(x => x.Id == id);

            return currentPet;
        }
    }
}

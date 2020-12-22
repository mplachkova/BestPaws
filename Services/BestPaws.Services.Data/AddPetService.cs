namespace BestPaws.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Web.ViewModels.PetCenter;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AddPetService : IAddPetService
    {
        private readonly IDeletableEntityRepository<Pet> petRepository;
        private readonly IDeletableEntityRepository<PetOwner> ownerRepository;
        private readonly IUserService userService;

        public AddPetService(IDeletableEntityRepository<Pet> petRepo, IDeletableEntityRepository<PetOwner> ownerRepo, IUserService service)
        {
            this.petRepository = petRepo;
            this.ownerRepository = ownerRepo;
            this.userService = service;
        }

        public async Task CreateAsync(AddPetInputModel input)
        {
            var user = new ApplicationUser
            {
                UserName = input.EmaiAddress,
                PhoneNumber = input.PhoneNumber,
            };

            this.userService.CreateUserAsync(user.UserName);

            var pet = new Pet
            {
                AnimalTypeId = input.AnimalTypeId,
                AnimalBreedId = input.AnimalBreedId,
                Age = input.Age,
                Name = input.Name,
                Gender = input.Gender,
                DoctorId = input.DoctorId,
                PetOwner = currentPetOwner,
            };

            await this.petRepository.AddAsync(pet);
            await this.petRepository.SaveChangesAsync();
        }
    }
}

namespace BestPaws.Services.Data
{
    using System.Threading.Tasks;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Web.ViewModels.PetCenter;

    public class AddPetService : IAddPetService
    {
        private readonly IDeletableEntityRepository<Pet> petRepository;

        public AddPetService(IDeletableEntityRepository<Pet> petRepository)
        {
            this.petRepository = petRepository;
        }

        public async Task CreateAsync(AddPetInputModel input)
        {
            var pet = new Pet
            {
                AnimalTypeId = input.AnimalTypeId,
                AnimalBreedId = input.AnimalBreedId,
                Age = input.Age,
                Name = input.Name,
                Gender = input.Gender,
            };

            await this.petRepository.AddAsync(pet);
            await this.petRepository.SaveChangesAsync();
        }
    }
}

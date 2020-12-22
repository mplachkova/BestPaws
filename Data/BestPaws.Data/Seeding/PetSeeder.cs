namespace BestPaws.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;

    public class PetSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Pets.Any())
            {
                return;
            }

            var petAnimalType = dbContext.AnimalTypes.FirstOrDefault(at => at.Name == "Cat");
            var petBreed = dbContext.AnimalBreeds.FirstOrDefault(ab => ab.Name == "British Shorthair");

            var currentPet = new Pet
            {
                Name = "Macho",
                AnimalType = petAnimalType,
                AnimalBreed = petBreed,
                Gender = Models.Enums.Gender.Male,
                Age = 11,
            };

            await dbContext.AddAsync(currentPet);
        }
    }
}

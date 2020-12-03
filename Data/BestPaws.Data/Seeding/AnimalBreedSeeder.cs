namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;

    public class AnimalBreedSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.AnimalBreeds.Any())
            {
                return;
            }

            var animalBreeds = new List<string>
            {
                "Abyssinian",
                "British Shorthair",
                "European Shorthair",
                "Bobtail",
                "Maine Coon",
                "Afghan Hound",
                "Akita",
                "Beagle",
                "German Shepherd",
                "Rottweiler",
                "Mini Rex",
                "Holland Lop",
                "Dutch Lop",
                "Dwarf Hotot",
                "Alpaca",
                "American",
                "Baldwin",
                "Coronet",
                "Unknown",
            };

            foreach (var breed in animalBreeds)
            {
                await dbContext.AddAsync(new AnimalBreed

                {
                    Name = breed,
                });
            }
        }
    }
}

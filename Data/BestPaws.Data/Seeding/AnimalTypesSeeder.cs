namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class AnimalTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.AnimalTypes.Any())
            {
                return;
            }

            var petTypes = new List<string>
            {
                "Cat",
                "Dog",
                "Rabbit",
                "Guinea pig",
            };

            foreach (var type in petTypes)
            {
                await dbContext.AnimalTypes.AddAsync(new AnimalType
                {
                    Name = type,
                });
            }
        }
    }
}

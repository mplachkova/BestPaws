namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore.Internal;
    using BestPaws.Data.Models;

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

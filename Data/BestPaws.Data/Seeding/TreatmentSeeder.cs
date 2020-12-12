namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;

    public class TreatmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Treatments.Any())
            {
                return;
            }

            var treatmentsList = new List<string>
            { "Vaccination", "Anti flea drop", "Deworming pill", "Grooming", "Nail clipping", "Microchipping", "Neutering", "Blood test", "Echography" };

            foreach (var treatment in treatmentsList)
            {
                var currentTreatment = new Treatment
                {
                    Name = treatment,
                };

                await dbContext.AddAsync(currentTreatment);
            }
        }
    }
}

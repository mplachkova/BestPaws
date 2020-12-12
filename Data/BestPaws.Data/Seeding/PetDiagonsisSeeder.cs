namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;

    public class PetDiagonsisSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var diagnosisList = new List<string> { "Diabetes", "FIV", "Influenza", "Lipidosis", "Dysplasia", "Gingivitis", "Chronic renal failure", "Obesity" };
            foreach (var disease in diagnosisList)
            {
                var currentDiagnosis = new Diagnosis
                {
                    Name = disease,
                };

                await dbContext.Diagnoses.AddAsync(currentDiagnosis);
            }
        }
    }
}

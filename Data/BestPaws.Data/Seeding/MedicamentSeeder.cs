namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;

    public class MedicamentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Medicaments.Any())
            {
                return;
            }

            var medicamentsList = new List<string> { "Irc vet", "Frontline", "Fiprist", "Kaniverm", "Advantage", "Canina slim", "VetoMune" };

            foreach (var medicament in medicamentsList)
            {
                var currentMedicament = new Medicament
                {
                    Name = medicament,
                };

                await dbContext.AddAsync(currentMedicament);
            }
        }
    }
}

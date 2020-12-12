namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;

    public class ReferenceValueSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ReferenceValues.Any())
            {
                if (dbContext.ReferenceValues.Any(x => x.Units == null))
                {
                    await AddMeasuringUnits(dbContext);
                    return;
                }

                return;
            }

            var referenceValueNames = new List<string> { "Albumin", "Globulin", "ALT", "AST", "g-GT", "Urea", "Creatinine", "Glucose", };

            var dogMaxReferenceValues = new List<decimal> { 44, 52, 118, 48.5m, 7, 8.9m, 124, 7.95m };

            var dogMinReferenceValues = new List<decimal> { 25, 23, 10, 8.9m, 0, 2.5m, 27, 3.89m };

            var catMaxReferenceValues = new List<decimal> { 45, 57, 100, 43m, 2, 10.7m, 141, 8.3m };

            var catMinReferenceValues = new List<decimal> { 27, 15, 20, 12, 0, 3.6m, 27, 3.9m };

            for (int i = 0; i < referenceValueNames.Count; i++)
            {
                var referenceValue = new ReferenceValue
                {
                    Name = referenceValueNames[i],
                    AnimalType = dbContext.AnimalTypes.FirstOrDefault(at => at.Name == "Dog"),
                    MaxValue = dogMaxReferenceValues[i],
                    MinValue = dogMinReferenceValues[i],
                };

                await dbContext.AddAsync(referenceValue);
            }

            for (int i = 0; i < referenceValueNames.Count; i++)
            {
                var referenceValue = new ReferenceValue
                {
                    Name = referenceValueNames[i],
                    AnimalType = dbContext.AnimalTypes.FirstOrDefault(at => at.Name == "Cat"),
                    MaxValue = catMaxReferenceValues[i],
                    MinValue = catMinReferenceValues[i],
                };

                await dbContext.AddAsync(referenceValue);
            }
        }

        private static async Task AddMeasuringUnits(ApplicationDbContext dbContext)
        {
            var measuringUnits = new Dictionary<string, string>()
            {
                { "Albumin", "g/l" },
                { "Globulin", "g/l" },
                { "ALT", "u/l" },
                { "AST", "u/l" },
                { "g-GT", "u/l" },
                {"Urea", "mmol/l" },
                { "Creatinine", "mmol/l" },
                { "Glucose", "mmol/l" },
            };

            foreach (var value in measuringUnits)
            {
                var query = dbContext.ReferenceValues.Where(x => x.Name == value.Key);
                foreach (var refValue in query)
                {
                    refValue.Units = value.Value;
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}

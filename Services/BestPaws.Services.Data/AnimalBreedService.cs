namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AnimalBreedService : IAnimalBreedService
    {
        private readonly IDeletableEntityRepository<AnimalBreed> breedRepository;

        public AnimalBreedService(IDeletableEntityRepository<AnimalBreed> breedRepository)
        {
            this.breedRepository = breedRepository;
        }

        public IEnumerable<SelectListItem> GetAllAnimalBreeds()
        {
            var breedList = this.breedRepository
                .AllAsNoTracking()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                })
                .OrderBy(x => x.Text)
                .ToList();
            return breedList;
        }
    }
}

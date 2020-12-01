namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AnimalTypeService : IAnimalTypeService
    {
        private readonly IDeletableEntityRepository<AnimalType> animalTypeRepository;

        public AnimalTypeService(IDeletableEntityRepository<AnimalType> repository)
        {
            this.animalTypeRepository = repository;
        }

        public IEnumerable<SelectListItem> GetAllAnimalTypes()
        {
            var animalTypesSelection = this.animalTypeRepository
                .AllAsNoTracking()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                })
                .ToList();
            return animalTypesSelection;
        }
    }
}

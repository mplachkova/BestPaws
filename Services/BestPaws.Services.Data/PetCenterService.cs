namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class PetCenterService : IPetCenterService
    {
        private readonly IDeletableEntityRepository<Pet> petRepository;

        public PetCenterService(IDeletableEntityRepository<Pet> petRepository)
        {
            this.petRepository = petRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var result = this.petRepository.All().To<T>().ToList();
            return result;
        }
    }
}

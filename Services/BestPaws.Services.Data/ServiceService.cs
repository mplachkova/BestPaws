namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class ServiceService : IServicesService
    {
        private readonly IDeletableEntityRepository<Service> repository;

        public ServiceService(IDeletableEntityRepository<Service> serviceRepository)
        {
            this.repository = serviceRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.repository.All().To<T>().ToList();
        }
    }
}

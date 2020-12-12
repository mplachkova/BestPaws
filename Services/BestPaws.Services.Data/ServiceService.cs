namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;
    using BestPaws.Web.ViewModels.Services;

    public class ServiceService : IServicesService
    {
        private readonly IDeletableEntityRepository<Service> repository;

        public ServiceService(IDeletableEntityRepository<Service> serviceRepository)
        {
            this.repository = serviceRepository;
        }

        public IEnumerable<ServiceViewModel> GetAll()
        {
            var descriptions = this.repository
                .All().To<ServiceViewModel>()
                .OrderBy(x => x.Description.Length)
                .ToList();

            for (int i = 0; i < descriptions.Count; i++)
            {
                var currentDescription = descriptions[i].Description;
                var descriptionAsArray = currentDescription.Split(' ');
                var newDescription = descriptionAsArray.Take(30);
                descriptions[i].Description = string.Join(' ', newDescription) + " ...";
            }

            return descriptions;
        }
    }
}

namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task CreateAsync(ServiceInputModel input)
        {
            var newService = new Service
            {
                Name = input.Name,
                Description = input.Description,
            };

            await this.repository.AddAsync(newService);
            await this.repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var serviceToDelete = this.repository.All().FirstOrDefault(x => x.Id == id);
            this.repository.Delete(serviceToDelete);
            await this.repository.SaveChangesAsync();
        }

        public async Task RestoreAsync(int id)
        {
            var serviceToRestore = this.repository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            serviceToRestore.IsDeleted = false;
            await this.repository.SaveChangesAsync();
        }

        public ServiceViewModel GetServiceById(int id)
        {
            return this.repository.All().To<ServiceViewModel>().FirstOrDefault(x => x.Id == id);
        }

        public async Task EditAsync(int id, ServiceViewModel model)
        {
            var editedService = this.repository.All().FirstOrDefault(x => x.Id == id);
            editedService.Name = model.Name;
            editedService.Description = model.Description;
            await this.repository.SaveChangesAsync();
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

        public IEnumerable<ServiceViewModel> GetAllWithDeleted()
        {
            var descriptions = this.repository
                .AllWithDeleted().To<ServiceViewModel>()
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

        public async Task Update(ServiceViewModel model)
        {
            var service = this.repository.All().FirstOrDefault(x => x.Id == model.Id);
            service.Description = model.Description;
            await this.repository.SaveChangesAsync();
        }

    }
}

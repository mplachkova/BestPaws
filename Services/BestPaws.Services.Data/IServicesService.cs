namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BestPaws.Web.ViewModels.Services;

    public interface IServicesService
    {
        IEnumerable<ServiceViewModel> GetAll();

        IEnumerable<ServiceViewModel> GetAllWithDeleted();

        Task CreateAsync(ServiceInputModel input);

        Task RestoreAsync(int id);

        Task DeleteAsync(int id);

        ServiceInputModel GetServiceById(int id);

        Task EditAsync(int id, ServiceInputModel model);
    }
}

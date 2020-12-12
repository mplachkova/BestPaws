namespace BestPaws.Services.Data
{
    using System.Collections.Generic;

    using BestPaws.Web.ViewModels.Services;

    public interface IServicesService
    {
        IEnumerable<ServiceViewModel> GetAll();
    }
}
